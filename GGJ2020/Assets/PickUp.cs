using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool isHolding;
    RaycastHit2D hit;
    public float distance=2f;
    public Transform holdpoint;

    void Start()
    {
        
    }

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.B))
        {
            if (!isHolding)
            {
                //grab

                Physics2D.queriesStartInColliders = false;

                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x,distance);
                Debug.Log(hit.collider);
                if(hit.collider!=null)
                {
                    isHolding = true;
                    Debug.Log(isHolding);
                    
                }

            }else
            {
                //throw
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
