using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHub : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HerbLand hubLand = collision.GetComponent<HerbLand>();
        if(hubLand != null)
        {
            Debug.Log("약초 터 발견");
        }
    }
}
