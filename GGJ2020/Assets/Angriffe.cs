using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angriffe : MonoBehaviour
{
    public float Geschwindigeit_Typ1;
    public Vector3 Anfangspos_Typ1;
    public GameObject feind1_prefab;
    
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            this.Angriff_Typ1();
        }
        
    }

    void Angriff_Typ1()
    {
        // Feind erschaffen
        GameObject feind = Instantiate(feind1_prefab, Anfangspos_Typ1, Quaternion.identity);

        //Feind fliegt los
        feind.GetComponent<Rigidbody2D>().AddForce(new Vector2(Geschwindigeit_Typ1 * Time.deltaTime, 0));
        feind.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(new Vector2(Geschwindigeit_Typ1 * Time.deltaTime, 0));

        // Feind greift an
        this.Warte(1000);
        feind.transform.GetChild(0).GetComponent<Rigidbody2D>().gravityScale = 1;

        //Feind fliegt weg
    }

    IEnumerator Warte(int sekunden)
    {
        yield return new WaitForSeconds(sekunden);
    }
}
