using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y <= -5)
        {
            gameObject.transform.position = new Vector3(-7f, -2.8f, -2f);
        }
    }
}
