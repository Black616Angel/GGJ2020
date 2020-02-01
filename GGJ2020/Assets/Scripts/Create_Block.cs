using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Create_Block : MonoBehaviour
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
        if (Input.GetKeyDown("space"))
        {
            int random = rnd.Next(0, prefabs_bloecke.Count);
            GameObject o = Instantiate(prefabs_bloecke[random], parent);

            GameObject k = Instantiate(prefab_plattform, o.transform);


            Debug.Log(k.gameObject.transform.localPosition.z);
            k.transform.localPosition = new Vector3(UnityEngine.Random.Range(-0.25f,0.25f), UnityEngine.Random.Range(-0.25f, 0.25f), k.transform.localPosition.z);


            Debug.Log(k.gameObject.transform.localPosition.z);

            created.Add(o);
            created[created.Count-1].AddComponent<blockcheck>();



            //Debug.Log(random);
        }

        

        if (Input.GetKeyDown(KeyCode.D))
        {
            foreach (GameObject l in created)
            {
                Destroy(l);
            }
        }
    }
}
