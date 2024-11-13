using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{
    public Transform _playerPosition;

    void LateUpdate()
    {
        Vector3 newPos = _playerPosition.transform.position;

        newPos.y = transform.position.y;

        transform.position = newPos;

        transform.rotation = Quaternion.Euler(90, _playerPosition.eulerAngles.y, 0);
    }
}
