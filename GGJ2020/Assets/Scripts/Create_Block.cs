using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class Create_Block : NetworkBehaviour
{
    public List<GameObject> prefabs_bloecke;
    public GameObject prefab_plattform;
    public Transform parent;
    System.Random rnd = new System.Random();

    List<GameObject> created = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            this.CmdcreateBlock();
        }

        

        if (Input.GetKeyDown(KeyCode.L))
        {
            this.CmddestroyBlock();
        }
    }

    [Command]
    void CmdcreateBlock()
    {
        int random = rnd.Next(0, prefabs_bloecke.Count);
        int drehung = rnd.Next(0, 4);
        int plat = rnd.Next(0, 2);
        GameObject o = Instantiate(prefabs_bloecke[random], parent);

        o.transform.position = new Vector3(-4.5f, 5f, 0);

        if (drehung == 0)
        {
            o.transform.eulerAngles = new Vector3(o.transform.eulerAngles.x, o.transform.eulerAngles.x, transform.eulerAngles.z + 90);
        }
        if (drehung == 1)
        {
            o.transform.eulerAngles = new Vector3(o.transform.eulerAngles.x, o.transform.eulerAngles.x, transform.eulerAngles.z - 90);
        }
        if (drehung == 2)
        {
            o.transform.eulerAngles = new Vector3(o.transform.eulerAngles.x, o.transform.eulerAngles.x, transform.eulerAngles.z + 180);
        }
        if (drehung == 3)
        {
            o.transform.eulerAngles = new Vector3(o.transform.eulerAngles.x, o.transform.eulerAngles.x, transform.eulerAngles.z);
        }
        NetworkServer.Spawn(o);

        if (plat == 0)
        {
            GameObject k = Instantiate(prefab_plattform, o.transform);
            k.transform.localPosition = new Vector3(UnityEngine.Random.Range(-0.25f, 0.25f), UnityEngine.Random.Range(-0.25f, 0.25f), k.transform.localPosition.z);
            NetworkServer.Spawn(k);
        }


       
        






        created.Add(o);
        created[created.Count - 1].AddComponent<blockcheck>();



        //Debug.Log(random);
    }

    [Command]
    void CmddestroyBlock()
    {
        foreach (GameObject l in created)
        {
            Destroy(l);
        }
    }

    
}
