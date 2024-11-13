using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class weapon : MonoBehaviour
{
    public Camera _camera;

    public Animator _anim;

    public float damage = 21;
    public float fireRate = 1;
    public float range = 15;
    public int _bulletsIn = 30;
    public int _bulletsAmount = 150;
    public int _reloadAmount = 30;
    public float nextFire = 0f;

    public Text currentAmmo;
    public Text maxAmmo;

    public GameObject hitEffect;
    public Transform _bulletSpawn;
        
    public AudioSource _source;
    public AudioClip _reloadingSound;
    public AudioClip _shotSFX;

    public float recoilTime = 0.1f;
    public float recoilIntens = 10.0f;
    public float spreadAngle = 30.0f;

    public bool _canShoot = true;

    PhotonView view;

    void Start()
    { 
        _anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        maxAmmo.text = _bulletsAmount.ToString();
    }

    void Update()
    {
        if (_canShoot)
        {
            if (Input.GetMouseButton(0) && Time.time > nextFire && _bulletsIn > 0)
            {
                nextFire = Time.time + 1f / fireRate;

                Shoot();

                _source.PlayOneShot(_shotSFX);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
            currentAmmo.text = _bulletsIn.ToString();
            maxAmmo.text = _bulletsAmount.ToString();
        }
    }

    void Reload()
    {
        _source.PlayOneShot(_reloadingSound);
        _bulletsAmount += _bulletsIn;
        _bulletsIn = 0;
        if(_bulletsAmount >= _reloadAmount)
        {
            _bulletsIn += _reloadAmount;
            _bulletsAmount -= _reloadAmount;
        }
        else
        {
            _bulletsIn = _bulletsAmount;
            _bulletsAmount = 0;
        }

    }

    void Shoot()
    {
        var _offset_first = Random.Range(-0.02f, 0.02f);
        var _offset_second = Random.Range(-0.02f, 0.02f);

        RaycastHit _hit;

        _bulletsIn -= 1;

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward + new Vector3(_offset_first, _offset_second), out _hit, range))
        {
            StartCoroutine(Recoil());

            if (_hit.collider.tag == "Player")
                return;

            if (_hit.collider.tag == "canBeShooted")
            {
                var _enemy = _hit.transform.GetComponent<HealthSystem>();;

                _enemy.transform.position += new Vector3(0.05f, 0f, 0.05f);

                _enemy._hp -= damage;
            }

            else
            {
                GameObject impact = Instantiate(hitEffect, _hit.point, Quaternion.LookRotation(_hit.normal));
                Destroy(impact, 10f);
            }
        }

    }

    IEnumerator Recoil()
    {
        Vector3 vLook = Vector3.zero;

        Vector3 vSpread = Quaternion.AngleAxis(Random.Range(-spreadAngle, +spreadAngle), transform.forward) * transform.up;

        Vector3 vRight = Vector3.Cross(transform.forward, vSpread);

        float elapsedTime = 0.0f;

        while (true)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > recoilTime)
            {
                if (elapsedTime > recoilTime * 2)
                {
                    yield break;
                }

                vLook = Quaternion.AngleAxis(recoilIntens * Time.deltaTime, -vRight) * transform.forward;
            }
            else
                vLook = Quaternion.AngleAxis(recoilIntens * Time.deltaTime, vRight) * transform.forward;

            transform.rotation = Quaternion.LookRotation(vLook);

            yield return null;
        }
    }
}
