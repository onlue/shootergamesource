using UnityEngine;
using UnityEngine.UI;

public class ItemsPickUpAndUse : MonoBehaviour
{

    [Header("Counters")]
    public Text _ammoKitsCount;
    public Text _medKitCount;
    public Text _ammoBullets;
    public Slider _health;

    [Header("MaxCountValues")]
    public int _ammoMaxCount;
    public int _medKitMaxCount;
    public int _maxAmmoInWeapon;

    [Header("AmmoRandomValues")]
    public int _minValue = 20;
    public int _maxValue = 50;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MedKit" && int.Parse(_medKitCount.text) <=_medKitMaxCount)
        {
            _medKitCount.text = (int.Parse(_medKitCount.text) + 1).ToString();
            Destroy(other.gameObject);
        }

        if(other.tag == "AmmoKit" && int.Parse(_ammoKitsCount.text) <= _ammoMaxCount)
        {
            _ammoKitsCount.text = (int.Parse(_ammoKitsCount.text) + 1).ToString();
            Destroy(other.gameObject);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4) && int.Parse(_ammoKitsCount.text) > 0)
        {
            gameObject.GetComponentInChildren<weapon>()._bulletsAmount += Random.Range(_minValue, _maxValue);
            _ammoKitsCount.text = (int.Parse(_ammoKitsCount.text) - 1).ToString();
        }

        if(Input.GetKeyDown(KeyCode.Alpha5) && int.Parse(_medKitCount.text) > 0)
        {
            gameObject.GetComponent<playerHealth>()._health += 30;
            _medKitCount.text = (int.Parse(_medKitCount.text) - 1).ToString();
        }
    }
}