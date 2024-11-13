using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crosshairChange : MonoBehaviour
{
    public Sprite[] _crosshairs;

    public Image _crosshair;

    public int _currenCross = 0;

    public float _crossSize = 0.5f;

    public void Awake()
    {
        _currenCross = PlayerPrefs.GetInt("crossId");
        _crosshair.sprite = _crosshairs[_currenCross];

        _crossSize = PlayerPrefs.GetFloat("crossSize");
        _crosshair.transform.localScale = new Vector2(_crossSize, _crossSize);
    }

    public void Start()
    {
        _crosshair.sprite = _crosshairs[_currenCross];
        _crosshair.transform.localScale = new Vector2(_crossSize, _crossSize);
    }

    public void IncCrossSize()
    {
        _crossSize += 0.1f;
        _crosshair.transform.localScale = new Vector2(_crossSize, _crossSize);
        PlayerPrefs.SetFloat("crossSize", _crossSize);
    }

    public void DecCrossSize()
    {
        _crossSize -= 0.1f;
        _crosshair.transform.localScale = new Vector2(_crossSize, _crossSize);
        PlayerPrefs.SetFloat("crossSize", _crossSize);
    }

    public void NextCross()
    {
        _currenCross += 1;

        if(_currenCross >= _crosshairs.Length)
        {
            _currenCross = 0;
        }

        _crosshair.sprite = _crosshairs[_currenCross];

        PlayerPrefs.SetInt("crossId", _currenCross);
    }

    public void PrevCross()
    {
        _currenCross -= 1;

        if (_currenCross <= 0)
        {
            _currenCross = _crosshairs.Length - 1;
        }

        _crosshair.sprite = _crosshairs[_currenCross];
        PlayerPrefs.SetInt("crossId", _currenCross);
    }
}
