using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        PlayerInput();   
    }

    private void PlayerInput()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            PlayerMove();
        }
    }

    private void PlayerMove()
    {
        if (Input.GetButton("Horizontal"))
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal")*Time.deltaTime,0));
        }
        if (Input.GetButton("Vertical"))
        {
            transform.Translate(new Vector2(0, Input.GetAxisRaw("Vertical")* Time.deltaTime));
        }
        
    }
}
