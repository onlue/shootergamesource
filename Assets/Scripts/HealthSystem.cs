using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float _hp = 100;

    public void FixedUpdate()
    {
        if(_hp <= 0)
        {
            GetComponentInChildren<EnemyDamage>()._Damage = 0;
        }
    }
}
