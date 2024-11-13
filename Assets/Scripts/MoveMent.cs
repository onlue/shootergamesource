using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class MoveMent : MonoBehaviour
{

    [Header("Player Speed")]
    public float _speed;
    public float _runningSpeed = 5f;
    public float _jumpSpeed;
    public float _gravity;

    [Header("Mouse Look")]
    float mouseX;
    float mouseY;
    public float mouseSensitivity = 100f;
    float xRotation;

    [Header("Player")]
    private Vector3 _direction;
    public CharacterController _char;
    public Transform player;

    [Header("Stamina")]
    public float _stamina = 10f;
    public float _staminaRegen = 5f;
    public float _runningCost = 10f;

    [Header("Visualisation Components")]
    public Slider _staminaSlider;

    [Header("Sounds")]
    public AudioSource _source;
    public AudioClip _stepClip;
    public AudioClip _runClip;

    void Start()
    {
        _char = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (_char.isGrounded)
        {
            bool _isRunning = Input.GetKey(KeyCode.LeftShift);

            if (_isRunning && _stamina > 0)
            {
                _direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * _speed * _runningSpeed;
                _stamina -= _runningCost * Time.deltaTime;
                if (!_source.isPlaying)
                {
                    _source.PlayOneShot(_runClip);
                }
            }
            else
            {
                _direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * _speed;
            }

            if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                if (!_source.isPlaying)
                {
                    _source.PlayOneShot(_stepClip);
                }
            }

            if (!_isRunning)
            {
                if(_stamina <= 100)
                {
                    _stamina += _staminaRegen * Time.deltaTime;
                }
            }

            _direction = transform.TransformDirection(_direction);

            _staminaSlider.value = _stamina;

            if (Input.GetKey(KeyCode.Space))
            {
                _direction.y += _jumpSpeed;
            }
        }
        else
        {
            _direction.y -= _gravity * Time.deltaTime;
        }
        _char.Move(_direction * Time.deltaTime);
    }

    void MouseLook()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        player.Rotate(Vector3.up * mouseY);

    }
}
