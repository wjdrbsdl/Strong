using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private float m_speed=5f;
    private float m_actionSpeed = 1f;
    private float m_curActionTime = 0f;
    private bool m_doneAction = false;
    private delegate void DeleDoAction();
    DeleDoAction actionHandler;
    // Update is called once per frame
    void Update()
    {
        PlayerInput();

        UpdateActionTime();
        if (m_doneAction)
            DoAction();
    }

    private void PlayerInput()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            PlayerMove();
        }
        if (Input.GetButton("Interact"))
        {
            FindHerb();
        }
    }
    
    private void PlayerMove()
    {
        if (Input.GetButton("Horizontal"))
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal")*Time.deltaTime*m_speed,0));
        }
        if (Input.GetButton("Vertical"))
        {
            transform.Translate(new Vector2(0, Input.GetAxisRaw("Vertical")* Time.deltaTime* m_speed));
        }
        
    }

    private void UpdateActionTime()
    {
        if (actionHandler == null)
            return;

        if (m_curActionTime > 2f)
            return;

        m_curActionTime += Time.deltaTime * m_actionSpeed;
        if (m_curActionTime > 2f)
            m_doneAction = true;

    }

    private void FindHerb()
    {
        m_curActionTime = 0f;
        actionHandler = FindHerbAction;
    }

    private void FindHerbAction()
    {
        Debug.Log("약초 찾기 운행");
    }

    private void DoAction()
    {
        actionHandler();
        m_curActionTime = 0;
        actionHandler = null;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        InteractObj interTarget = collision.GetComponent<InteractObj>();
        interTarget.Interact();
    }
}
