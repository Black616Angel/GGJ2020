using System;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool isHolding;
    GameObject hitObj;
    public float distance=2f;
    public Transform holdpoint;
    public float throwForce;

    private GameObject gridChecker;
    private bool spotFree = false;

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

                if(isHolding)
                {
                    foreach (Collider2D coll in hit.collider.gameObject.GetComponents<Collider2D>())
                    {
                        coll.enabled = false;
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
                    foreach (Collider2D coll in hitObj.GetComponentsInChildren<Collider2D>())
                    {
                        coll.enabled = true;
                    }
                    if(gridChecker)
                    {
                        //gridChecker = null;
                        Destroy(gridChecker);
                        gridChecker = null;
                    }
                    hitObj = null;
                }
            }
        }

        if (isHolding)
        {
            if(hitObj is null)
            {
                hitObj = hit.transform.gameObject; // wir wollen das GameObject drüber
                hitObj.GetComponent<Rigidbody2D>().freezeRotation = true;
                hitObj.transform.rotation = new Quaternion(0,0,0,0);

            }
            hitObj.transform.position = new Vector3(holdpoint.position.x, holdpoint.position.y, hitObj.transform.position.z);
            if(gridChecker is null)
            {
                gridChecker = Instantiate(hitObj, transform); // Kopie des gameObjects als Sucher instanziieren
                foreach (Collider2D coll in gridChecker.GetComponentsInChildren<Collider2D>())
                {
                    if (!coll.isTrigger)
                        coll.enabled = false;
                }
                Grid_Checker_Scale();

            }
            FindNextSpot();

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                hitObj.transform.Rotate(new Vector3(0, 0, 90));

                gridChecker.transform.Rotate(new Vector3(0, 0, 90));
                Grid_Checker_Scale();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                hitObj.transform.Rotate(new Vector3(0, 0, -90));

                gridChecker.transform.Rotate(new Vector3(0, 0, -90));
                Grid_Checker_Scale();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                isHolding = false;
                //hitObj.transform.position = gridChecker.transform.position;
                hitObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                hitObj.GetComponent<Rigidbody2D>().gravityScale = 1;
                hitObj.GetComponent<Rigidbody2D>().freezeRotation = false;
                foreach (Collider2D coll in hitObj.GetComponentsInChildren<Collider2D>())
                {
                    coll.enabled = true;
                }
                hitObj.transform.position = gridChecker.transform.position;

                if (gridChecker)
                {
                    Destroy(gridChecker);
                    gridChecker = null;
                    //Destroy(gridChecker);
                }
                hitObj = null;
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position+Vector3.right*transform.localScale.x * distance);
    }

    /*
    private void FindNextSpot()
    {
        gridChecker.transform.position = new Vector3(
        (float)(Math.Round(transform.position.x + transform.localScale.x * 2f * 4, MidpointRounding.AwayFromZero)) / 2f,
        (float)(Math.Round(transform.position.y * 2f, MidpointRounding.AwayFromZero)) / 2f,
        (float)(Math.Round(transform.position.z * 2f, MidpointRounding.AwayFromZero)) / 2f
            );
        gridChecker.transform.localScale = new Vector3(2, gridChecker.transform.localScale.y, gridChecker.transform.localScale.z);
    }
    */

    private void FindNextSpot()
    {
        float grid_x = 1;
        float grid_y = 1;

        float über_x = (transform.localPosition.x + 1000*grid_x) % grid_x;
        float über_y = (transform.localPosition.y + 1000 * grid_y) % grid_y;

        float snap_x = transform.position.x - über_x + 2 * grid_x;
        float snap_y = transform.position.y - über_y + 2 * grid_y;

        gridChecker.transform.position = new Vector3(
            snap_x,
            snap_y,
            gridChecker.transform.position.z

        );

 

    }

    private void Grid_Checker_Scale()
    {
        float rotation = gridChecker.transform.rotation.z * 180 / Mathf.PI;

        Debug.Log("Scale: Rotation = " + rotation);
        Debug.Log(Mathf.RoundToInt(rotation));
        Debug.Log(Math.Abs(Mathf.RoundToInt(rotation)));

        Vector3 scale_vector = new Vector3();
        switch (Math.Abs(Mathf.RoundToInt(rotation)))
        {
            case 0:
                Debug.Log("0");
                scale_vector = new Vector3(2, 1, 1);
                break;
            case 41:
                scale_vector = new Vector3(1, 2, 1);
                Debug.Log("41");
                break;
            case 57:
                scale_vector = new Vector3(2, 1, 1);
                Debug.Log("57");
                break;
            case 270:
                scale_vector = new Vector3(1, 2, 1);
                Debug.Log("270");
                break;
        }
        gridChecker.transform.localScale = scale_vector;
    }


}
