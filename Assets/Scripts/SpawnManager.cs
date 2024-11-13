using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] _spawns;

    public GameObject _player;

    private void Awake()
    {
        Vector3 _rndPos = _spawns[Random.RandomRange(0, _spawns.Length)].transform.localPosition;

        PhotonNetwork.Instantiate(_player.name,_rndPos + new Vector3(0f,14f,0f),Quaternion.identity);
    }
}
