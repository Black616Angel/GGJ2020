using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    public char reset_button;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(reset_button.ToString()))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
