using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement : MonoBehaviour
{

    public GameObject Spieler;
    public float Versatz;

    public GameObject PlayerMau;
    public GameObject PlayerChan;

    // Start is called before the first frame update
    void Start()
    {

        //setze Maurizio als gewählten Charakter
        if (PlayerPrefs.GetInt("SelecectedCharakter") == 0)
        {
            PlayerMau.SetActive(true);
            Spieler = PlayerMau;
        }
        //setze Chanterella als gewählten Charakter
        if (PlayerPrefs.GetInt("SelecectedCharakter") == 1)
        {
            PlayerChan.SetActive(true);
            Spieler = PlayerChan;
        }

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
