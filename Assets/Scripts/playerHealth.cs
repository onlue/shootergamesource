using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public float _health;

    public float _armor;

    public Slider _healthBar;

    public void LateUpdate()
    {
        _healthBar.value = _health;
        CanShoot();
    }

    public void CanShoot()
    {
        if(_health <= 0)
        {
            GetComponentInChildren<weapon>()._canShoot = false;
            GetComponentInChildren<weaponStorage>()._canChangeWeapons = false;
        }
    }
}
