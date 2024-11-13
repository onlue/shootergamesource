using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponStorage : MonoBehaviour
{
    public List<GameObject> _unlockedWeapons = new List<GameObject>();
    public GameObject[] _allWeapons;

    public bool _canChangeWeapons = true;

    public AudioClip _changeWeaponSound;
    public AudioSource _source;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (_canChangeWeapons)
            {
                _source.PlayOneShot(_changeWeaponSound);
                SwitchWeapon();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("pickWeapon"))
        {
            for (int i = 0; i < _allWeapons.Length; i++)
            {
                if(other.name == _allWeapons[i].name)
                {
                    _unlockedWeapons.Add(_allWeapons[i]);
                }
            }
            Destroy(other.gameObject);
        }
    }

    public void SwitchWeapon()
    {
        bool _isNotFind = true;

        for (int i = 0; i < _unlockedWeapons.Count; i+=1)
        {
            if (_unlockedWeapons[i].activeInHierarchy)
            {
                _unlockedWeapons[i].SetActive(false);

                if(i != 0)
                {
                    _unlockedWeapons[i - 1].SetActive(true);
                    _isNotFind = false;
                }
                else
                {
                    _unlockedWeapons[_unlockedWeapons.Count - 1].SetActive(true);
                    _isNotFind = false;
                }
                break;
            }
        }
        if (_isNotFind)
        {
            _unlockedWeapons[0].SetActive(true);
        }
            
    }
}
