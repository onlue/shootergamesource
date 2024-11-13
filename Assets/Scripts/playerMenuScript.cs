using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMenuScript : MonoBehaviour
{
    public GameObject _menu;

    public GameObject _player;

    bool _menuState = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _menuState = !_menuState;
        }
        if (_menuState && GetComponent<playerHealth>()._health > 0)
        {
            _menu.SetActive(true);

            _player.GetComponentInChildren<FirstPersonLook>().enabled = false;
            _player.GetComponentInChildren<weapon>().enabled = false;

            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            _menu.SetActive(false);

            _player.GetComponentInChildren<FirstPersonLook>().enabled = true;

            _player.GetComponentInChildren<weapon>().enabled = true;


            Cursor.lockState = CursorLockMode.Locked;
        }
    }


    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OffMenu()
    {
        _menu.SetActive(false);
            
        _player.GetComponentInChildren<FirstPersonLook>().enabled = true;
        _player.GetComponentInChildren<weapon>().enabled = true;


        Cursor.lockState = CursorLockMode.Locked;

        _menuState = false;

    }
}
