using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject m_player;

    private void Update()
    {
        Vector3 pos = m_player.transform.position;
        pos.z = -10f;
        transform.position = pos;
    }
}
