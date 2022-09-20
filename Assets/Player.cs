using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();   
    }

    private void PlayerInput()
    {
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            PlayerMove();
        }
    }

    private void PlayerMove()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal"),0));
        }
        if (Input.GetButtonDown("Vertical"))
        {
            transform.Translate(new Vector2(0, Input.GetAxisRaw("Vertical")));
        }
    }
}
