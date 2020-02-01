using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class blockcheck : NetworkBehaviour
{
    public float boden_pos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}
