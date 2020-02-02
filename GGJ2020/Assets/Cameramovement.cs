using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement : MonoBehaviour
{

    public GameObject Spieler;
    public float Versatz;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Spieler.transform.position.y >= Versatz)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, Spieler.transform.position.y, gameObject.transform.position.z);
        }
    }
}
