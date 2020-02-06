using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angriffe : MonoBehaviour
{
    public Vector3 Anfangspos_Typ1;
    public float Geschwindigeit_Typ1;
    public GameObject feind1_prefab;
    public Vector3 Anfangspos_Wind;
    public float stärkeWindstoß;
    public float Geschwindigeit_Wind;
    public float sekWindZerstören;
    public GameObject windstoss_prefab;
    public Vector3 Anfangspos_Typ2;
    public GameObject vieh_prefab;


    private void Start()
    {
        InvokeRepeating("Angriff_Typ2", 0f, 10f);
    }


    void Update()
    {
        /*if (Input.GetKeyDown("a"))
        {
            this.Angriff_Typ1();
        }

        if (Input.GetKeyDown("w"))
        {
            this.Angriff_Wind();
        }

        if (Input.GetKeyDown("e"))
        {
            this.Angriff_Erdbeben();
        }

        if (Input.GetKeyDown("v"))
        {
            this.Angriff_Typ2();
        }
        */
    }

    void Angriff_Typ1()
    {
        // Feind erschaffen
        GameObject feind = Instantiate(feind1_prefab, Anfangspos_Typ1, Quaternion.identity);

        //Feind fliegt los
        feind.GetComponent<Rigidbody2D>().AddForce(new Vector2(Geschwindigeit_Typ1, 0));
        feind.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(new Vector2(Geschwindigeit_Typ1, 0));

        // Feind greift an
        feind.transform.GetChild(0).GetComponent<Rigidbody2D>().gravityScale = 1;

        //Feind fliegt weg und wird zerstört
        StartCoroutine(zerstöre_nach_zeit(5, feind));
    }

    void Angriff_Typ2()
    {
        if (Random.Range(0, 100) < 5f)
        {
            if (GameObject.FindGameObjectsWithTag("Block").GetLength(0) > 0)
            {
                GameObject feind = Instantiate(vieh_prefab, Anfangspos_Typ2, Quaternion.identity);
            }
        }
        // Feind erschaffen wenn es noch Blöcke gibt
        
    }

    void Angriff_Wind()
    {

        GameObject[] blöcke = GameObject.FindGameObjectsWithTag("Block");
        GameObject wind_bild = Instantiate(windstoss_prefab, Anfangspos_Wind, Quaternion.identity);
        wind_bild.GetComponent<Rigidbody2D>().AddForce(new Vector2(Geschwindigeit_Wind, 0));
        
        foreach (GameObject block in blöcke)
        {
            if (Random.value < 0.4)
            {
                Debug.Log("Wind");
                block.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.value* stärkeWindstoß, Random.value* stärkeWindstoß));
            }
        }
        

        //Nach x Sekunden zerstören
        StartCoroutine(zerstöre_nach_zeit(sekWindZerstören, wind_bild));
    }

    void Angriff_Erdbeben()
    {
        GameObject[] bodenelemente = GameObject.FindGameObjectsWithTag("Boden");

        foreach (GameObject bodenelement in bodenelemente)
        {
            bodenelement.GetComponent<erdbeben>().start = true;
        }
    }


    IEnumerator zerstöre_nach_zeit(float sekunden, GameObject obj)
    {
        Debug.Log(Time.time);
        yield return new WaitForSeconds(sekunden);
        Debug.Log(Time.time);

        Destroy(obj);
    }
    
}
