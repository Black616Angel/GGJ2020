using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Charakterauswahl : MonoBehaviour
{

    public GameObject arrowLeft;
    public GameObject arrowRight;

    private int choosenCharakter = 0;  // 0 - Maurizio; 1-Chanterella

    // Start is called before the first frame update
    void Start()
    {
        arrowRight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //choose Chanterella
        if (Input.GetKeyDown(KeyCode.D) && choosenCharakter == 0)
        {
            arrowLeft.SetActive(false);
            arrowRight.SetActive(true);
            choosenCharakter = 1;
        }
        //choose Maurizio
        if (Input.GetKeyDown(KeyCode.A) && choosenCharakter == 1)
        {
            arrowRight.SetActive(false);
            arrowLeft.SetActive(true);
            choosenCharakter = 0;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayerPrefs.SetInt("SelecectedCharakter",choosenCharakter);
            SceneManager.LoadScene(2);
        }
    }
}
