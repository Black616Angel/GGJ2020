using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool isHolding;
    RaycastHit2D hit;
    public float distance=2f;
    public Transform holdpoint;
    public float throwForce;

    void Start()
    {
        
    }

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isHolding)
            {
                //grab

                Physics2D.queriesStartInColliders = false;

                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x,distance);
                
                if(hit.collider!=null)
                {
                    isHolding = true;
                    
                    
                }

            }else
            {
                //throw
                isHolding = false;
                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x,1) * throwForce;
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                }
            }


        }

        if (isHolding)
        {
            hit.collider.gameObject.transform.position = holdpoint.position;
        }

    }


    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position+Vector3.right*transform.localScale.x * distance);
    }
    
}
