
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private float m_speed=5f;
    private float m_actionSpeed = 1f;
    private float m_curActionTime = 0f;
    private bool m_isReadyToAct = false;
    private delegate void DelegateAction();
    DelegateAction m_actionHandler;
    // Update is called once per frame
    void Update()
    {
        PlayerInput();

        UpdateActionTime();
        if (m_isReadyToAct)
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
        if (m_actionHandler == null)
            return;

        if (m_curActionTime > 2f)
            return;

        m_curActionTime += Time.deltaTime * m_actionSpeed;
        if (m_curActionTime > 2f)
            m_isReadyToAct = true;

    }

    private void FindHerb()
    {
        m_curActionTime = 0f;
        int ranAction = Random.Range(0, 3);
        if (ranAction == 0)
            m_actionHandler = FindHerbAction;
        else if (ranAction == 1)
            m_actionHandler = CutHerbAction;
        else if (ranAction == 2)
            m_actionHandler = MakeHerbAction;
    }

    private void FindHerbAction()
    {
        Debug.Log("약초 찾기 운행");
        
    }

    private void CutHerbAction()
    {
        Debug.Log("약초 자르기");
    }

    private void MakeHerbAction()
    {
        Debug.Log("약초 만들기");
    }

    private void DoAction()
    {
        m_actionHandler();
        m_curActionTime = 0;
        m_actionHandler = null;
        m_isReadyToAct = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        InteractObj interTarget = collision.GetComponent<InteractObj>();
        interTarget.Interact();
    }
}
