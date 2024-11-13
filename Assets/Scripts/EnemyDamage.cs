using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float _Damage = 10;

    public AudioSource _source;
    public AudioClip _DamageSound;

    public void Start()
    {
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            col.GetComponent<playerHealth>()._health -= _Damage;
            _source.PlayOneShot(_DamageSound);
        }
    }
}
