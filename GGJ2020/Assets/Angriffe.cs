using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angriffe : MonoBehaviour
{
    public float Geschwindigeit_Typ1;
    public Vector3 Anfangspos_Typ1;
    public float stärkeWindstoß;
    public GameObject feind1_prefab;
    
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            this.Angriff_Typ1();
        }

        if (Input.GetKeyDown("w"))
        {
            this.Angriff_Wind();
        }

    }

    void Angriff_Typ1()
    {
        // Feind erschaffen
        GameObject feind = Instantiate(feind1_prefab, Anfangspos_Typ1, Quaternion.identity);

        //Feind fliegt los
        feind.GetComponent<Rigidbody2D>().AddForce(new Vector2(Geschwindigeit_Typ1, 0));
        feind.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(new Vector2(Geschwindigeit_Typ1, 0));

        // Feind greift an
        this.Warte(1000);
        feind.transform.GetChild(0).GetComponent<Rigidbody2D>().gravityScale = 1;

        //Feind fliegt weg
    }

    void Angriff_Wind()
    {
        GameObject[] blöcke = GameObject.FindGameObjectsWithTag("Block");

        foreach (GameObject block in blöcke)
        {
            if (Random.value < 0.2)
            {
                Debug.Log("Wind");
                block.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.value* stärkeWindstoß, Random.value* stärkeWindstoß));
            }
        }
    }

    IEnumerator Warte(int sekunden)
    {
        yield return new WaitForSeconds(sekunden);
    }
}
