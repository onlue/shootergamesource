using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer _MIXER; 

    public GameObject _settingsMenu;

    public GameObject _mainMenu;

    public Dropdown _dropdownSettings;

    public Slider _volumeSlider;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        _dropdownSettings.value = PlayerPrefs.GetInt("Quality");
        QualitySettings.SetQualityLevel(_dropdownSettings.value);
        _MIXER.SetFloat("volume", PlayerPrefs.GetFloat("Volume"));
        _volumeSlider.value = PlayerPrefs.GetFloat("VolumeLevel");
        Debug.Log(PlayerPrefs.GetFloat("VolumeLevel"));
    }

    public void Play()
    {
        SceneManager.LoadScene(3);
    }

    public void Settings()
    {
        _settingsMenu.SetActive(true);
        _mainMenu.SetActive(false);
    }

    public void ExitSettings()
    {
        _settingsMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(_dropdownSettings.value+1);
        PlayerPrefs.SetInt("Quality", _dropdownSettings.value);
    }

    public void SetVolume(float _volume)
    {
        _MIXER.SetFloat("volume",Mathf.Log10(_volume)*20);
        PlayerPrefs.SetFloat("VolumeLevel", _volume);
    }

    public void PauseSound()
    {
        AudioListener.pause = !AudioListener.pause;
        if (AudioListener.pause)
        {
            PlayerPrefs.SetInt("isPausedVolume", 0);
        }
        else
        {
            PlayerPrefs.SetInt("isPausedVolume", 1);
        }
    }

    public void MultyPlayer()
    {
        SceneManager.LoadScene(1);
    }
}
