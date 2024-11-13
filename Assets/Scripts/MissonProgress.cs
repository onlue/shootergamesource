using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MissonProgress : MonoBehaviour
{

    public Text _currentProgress;

    public int _obtainToComplete;

    public GameObject _exitBlock;

    public GameObject ExitOutline;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _currentProgress.text = (int.Parse(_currentProgress.text) + 1).ToString();
            Destroy(gameObject);
        }
        if (int.Parse(_currentProgress.text) == _obtainToComplete)
        {
            _currentProgress.text = "Доберитесь до выхода";
            ExitOutline.AddComponent<Outline>();
        }
    }

}
