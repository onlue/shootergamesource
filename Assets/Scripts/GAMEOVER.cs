using UnityEngine.SceneManagement;
using UnityEngine;

public class GAMEOVER : MonoBehaviour
{
    public GameObject _player;

    public GameObject _playerGameOverMenu;

    public void LateUpdate()
    {
        if(_player.GetComponent<playerHealth>()._health <= 0)
        {
            _player.GetComponent<MoveMent>().enabled = false;

            _playerGameOverMenu.SetActive(true);

            _player.GetComponentInChildren<FirstPersonLook>().enabled = false;

            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(3);
    }
}
