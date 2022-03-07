using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Transform pos;

    private IsOnTheGround grounded;

    [SerializeField]private float movementSpeed = 5f;
    [SerializeField]private float jumpForce = 5f;
    [SerializeField]private float fallSpeed = 5f;

    private float fallTime = 0.0f;
    private float fallVel;
    private float moveTime = 0.0f;
    private float moveVel;


    private void Start()
    {
        pos = GetComponent<Transform>();
        grounded = GetComponent<IsOnTheGround>();
    }

    private void Update()
    {
        Gravity();
        Movement();
    }

    //Poruszanie sie
    private void Movement()
    {
        float dir = Input.GetAxisRaw("Horizontal");
        pos.position = pos.position + new Vector3(movementSpeed * dir * Time.deltaTime, 0f);
    }

    private void Gravity()
    {
        if(!Groundcheck())
        {
            pos.position = pos.position + new Vector3(0f, GetFallSpeed() * Time.deltaTime);
        }
        else if(Groundcheck())
        {
            fallTime = 0;
        }
    }

    //sprawdza czy postaæ jest na ziemi na podstawie skryptu IsOnTheGround
    private bool Groundcheck()
    {
        return grounded.GetIsGroundedBool();
    }

    //Predkosc spadania
    private float GetFallSpeed()
    {
        fallTime += Time.deltaTime;
        if(fallTime < 3)
        {
            fallVel = fallSpeed * fallTime * fallTime;
        }
        return -fallVel;
    }

    //dorób to do koñca i dorób skakanie
    private float GetMoveSpeed()
    {
        moveTime += Time.deltaTime;
        if(moveTime < 3)
        {
            moveVel = movementSpeed * moveTime * moveTime;
        }
        return moveVel;
    }
}
