using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector2 position = new Vector2(0f, 0f);
    private Rigidbody rb;
    public float HVelocity;
    public float VVelocity;

    public bool IsGrounded;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
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

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.Space)) //Jump
        {
            MoveVertically(VerticalMovement.up);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S))// Rechts
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
        switch (direction)
        {
            case HorizontalMovement.left:
                HVelocity = -0.5f;
                break;
            case HorizontalMovement.right:
                HVelocity = 0.5f;
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

        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x + HVelocity, -1f, 1f), rb.velocity.y, 0);
    }

    private void MoveVertically(VerticalMovement direction)
    {
        switch (direction)
        {
            case VerticalMovement.down:
                VVelocity = -0.5f;
                break;
            case VerticalMovement.up:
                if(IsGrounded)
                    VVelocity = 5f;
                break;
            case VerticalMovement.stop:
                if (IsGrounded)
                    VVelocity = 0f;
                else
                    VVelocity = -0.2f;
                break;
        }

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + VVelocity, 0);
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        IsGrounded = true;
    }

    void OnCollisionExit(Collision collisionInfo)
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
