using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text score_text;


    float max_y;

    private void Start()
    {
        max_y = -3.2f;
    }


    void Update()
    {
        GameObject[] blöcke = GameObject.FindGameObjectsWithTag("Block");

        

        foreach (GameObject block in blöcke)
        {
            if (block.transform.position.y > max_y) max_y = block.transform.position.y;
        }

        int score = Mathf.RoundToInt(max_y*3) + Mathf.RoundToInt(3.2f*3);

        score_text.text = "Score: " + score.ToString();

    }
}
