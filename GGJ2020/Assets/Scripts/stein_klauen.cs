using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stein_klauen : MonoBehaviour
{
    public float geschwindigkeit;
    public Vector2 abflugZiel;

    GameObject zielBlock;
    bool hat_block = false;

    // Start is called before the first frame update
    void Start()
    {
        //var random = new Random();
        
        GameObject[] blöcke = GameObject.FindGameObjectsWithTag("Block");

        zielBlock = blöcke[Random.Range(0, blöcke.GetLength(0))];

        zielBlock.tag = "Getragener_Block";

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posGetragenerBlock;
        Vector2 richtungsVektor = new Vector2();

        //Block andocken
        if ((((Vector2)(transform.position-zielBlock.transform.position)).magnitude > 0.5) && (hat_block == false))
        {
            //Richtungsvektor zu Block bilden
            richtungsVektor = new Vector2(zielBlock.transform.position.x - transform.position.x, zielBlock.transform.position.y - transform.position.y);

            //Vektor normieren
            richtungsVektor = richtungsVektor * (1 / richtungsVektor.magnitude);

            transform.position += (Vector3) (richtungsVektor) * (geschwindigkeit * Time.deltaTime);
        }

        //Block tragen
        if ((((Vector2)(transform.position - zielBlock.transform.position)).magnitude <= 0.5) || (hat_block == true))
        {
            posGetragenerBlock = transform.position;
            posGetragenerBlock.z = 0;
            zielBlock.transform.position = posGetragenerBlock;

            for(int j = 0; j < zielBlock.transform.childCount; j++)
            {
                zielBlock.transform.GetChild(j).GetComponent<BoxCollider2D>().enabled = false;
            }

            hat_block = true;
        }

        // Weg fliegen
        if (hat_block)
        {
            //Richtungsvektor zu Abflug Ziel bilden
            richtungsVektor = abflugZiel - (Vector2)transform.position;

            //Vektor normieren
            richtungsVektor = richtungsVektor * (1 / richtungsVektor.magnitude);

            transform.position += (Vector3)(richtungsVektor) * (geschwindigkeit * Time.deltaTime);
            //transform.position = new Vector3(0, 0, 0);
        }

        //Block und Selbst Löschen, wenn Abflug Ziel erreicht

        if ((((Vector2) transform.position - abflugZiel).magnitude <= 0.5) && (hat_block == true))
        {
            Destroy(zielBlock);
            Destroy(gameObject);
        }
    }
}
