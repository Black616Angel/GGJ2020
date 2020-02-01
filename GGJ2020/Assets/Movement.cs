using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float horSpeed;
    public float verSpeed;

    public Vector2 position = new Vector2(0f, 0f);
    private Rigidbody2D rb;
    float HVelocity;
    float VVelocity;

    bool IsGrounded;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

        if (horSpeed == 0)
            horSpeed = 1;
        if (verSpeed == 0)
            verSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        position.x = (float)(Math.Round(transform.position.x * 2f, MidpointRounding.AwayFromZero)) / 2f;
        position.y = (float)(Math.Round(transform.position.y * 2f, MidpointRounding.AwayFromZero)) / 2f;

        if (Input.GetKey(KeyCode.A)) //Links
        {
            MoveHorizontally(HorizontalMovement.left);
        }
        else
        {
            if (Input.GetKey(KeyCode.D))// Rechts
            {
                MoveHorizontally(HorizontalMovement.right);
            }
            else // keine horizontale Bewegung
            {
                MoveHorizontally(HorizontalMovement.stop);
            }
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) //Jump
        {
            MoveVertically(VerticalMovement.up);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S))// Down
            {
                MoveVertically(VerticalMovement.down);
            }
            else // keine horizontale Bewegung
            {
                MoveVertically(VerticalMovement.stop);
            }
        }

    }

    private void MoveHorizontally(HorizontalMovement direction)
    {

        int facing = 0;
        bool directionChange = false;

        switch (direction)
        {
            case HorizontalMovement.left:
                HVelocity = -1 * horSpeed;
                break;
            case HorizontalMovement.right:
                HVelocity = horSpeed;
                break;
            case HorizontalMovement.stop:
                if (rb.velocity.x <= -0.2f)
                    HVelocity = 0.2f;
                else if (rb.velocity.x >= 0.2f)
                    HVelocity = -0.2f;
                else
                    HVelocity = rb.velocity.x * -1;
                break;
        }


        if (rb.velocity.x < 0)
            facing = -1;
        else if (rb.velocity.x > 0)
            facing = 1;
        else
            facing = (int)(2 * transform.localScale.x);

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x + HVelocity, -2 * horSpeed, 2 * horSpeed), rb.velocity.y);

        if (rb.velocity.x < 0 && facing == 1)
            directionChange = true;
        else if (rb.velocity.x > 0 && facing == -1)
            directionChange = true;

        if (directionChange)
        {
            transform.localScale = new Vector3(-1 * (float)facing / 2, transform.localScale.y,transform.localScale.z);
            //Debug.Log("direction");
        }

        //Debug.Log("facing: " + facing + " velocity: " + rb.velocity.x + " localScale: " + transform.localScale.x);

    }

    private void MoveVertically(VerticalMovement direction)
    {
        switch (direction)
        {
            case VerticalMovement.down:
                VVelocity = -1 * verSpeed / 10;
                break;
            case VerticalMovement.up:
                if(IsGrounded)
                    VVelocity = verSpeed;
                IsGrounded = false;
                break;
            case VerticalMovement.stop:
                if (IsGrounded)
                    VVelocity = 0f;
                else
                    VVelocity = -0.2f;
                //IsGrounded = false;
                break;
        }

        rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y + VVelocity, -1000, verSpeed));
    }

    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        IsGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        IsGrounded = false;
    }

    enum HorizontalMovement
    {
        right,
        left,
        stop
    }

    enum VerticalMovement
    {
        up,
        down,
        stop
    }
}
