using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool isHolding;
    GameObject hitObj;
    public float distance=2f;
    public Transform holdpoint;
    public float throwForce;

    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit2D hit = new RaycastHit2D();
      if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isHolding)
            {
                //grab

                Physics2D.queriesStartInColliders = false;

                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x,distance);
                
                if(hit.collider != null)
                {
                    foreach( Collider2D coll in hit.collider.gameObject.GetComponents<Collider2D>())
                    {
                        if (coll.isTrigger)
                            isHolding = true;
                    }
                }

            }else
            {
                //throw
                isHolding = false;
                if (hitObj.GetComponent<Rigidbody2D>() != null)
                {
                    hitObj.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x,1) * throwForce;
                    hitObj.GetComponent<Rigidbody2D>().gravityScale = 1;
                    hitObj.GetComponent<Rigidbody2D>().freezeRotation = false;
                }
            }
        }

        if (isHolding)
        {
            if(hitObj is null)
            {
                hitObj = hit.transform.parent.gameObject; // wir wollen das GameObject drüber
                hitObj.GetComponent<Rigidbody2D>().freezeRotation = true;
            }
            hitObj.transform.position = new Vector3(holdpoint.position.x, holdpoint.position.y, hitObj.transform.position.z);

            FindNextSpot();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position+Vector3.right*transform.localScale.x * distance);
    }

    private void FindNextSpot()
    {
        Movement mov = gameObject.GetComponent<Movement>();
        int dir = (int)(transform.localScale.x * 2f);
    }


}
