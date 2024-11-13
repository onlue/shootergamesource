using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    public Animator _animation;

    public GameObject _target;

    private bool _isAlive = true;

    float _distance;
    NavMeshAgent _agent;

    public AudioSource _source;
    public AudioClip _stepClips;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        var _playerHealth = _target.GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAlive)
        {
            _distance = Vector3.Distance(_target.transform.position, transform.position);
            if (_distance >= 15)
            {
                _agent.enabled = false;
                _animation.SetBool("damage", false);
                _animation.SetFloat("speed", 0f);
            }
            else if (_distance <= 2.0f)
            {
                _agent.enabled = false;
                _animation.SetFloat("speed", 0f);
                _animation.SetBool("damage", true);
            }
            else if (_distance <= 15)
            {
                _agent.enabled = true;
                _agent.SetDestination(_target.transform.position);
                _animation.SetBool("damage", false);
                _animation.SetFloat("speed", 0.11f);
                if (!_source.isPlaying)
                {
                    _source.PlayOneShot(_stepClips);
                }
            }
            if (GetComponent<HealthSystem>()._hp <= 0)
            {
                _animation.SetBool("damage", false);
                _animation.SetFloat("speed", 0f);
                _animation.SetBool("death", true);
                _isAlive = false;
                Destroy(gameObject, 15f);
                _agent.enabled = false;
            }
        }
    }
}
