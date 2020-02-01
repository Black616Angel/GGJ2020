using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class erdbeben : MonoBehaviour
{
    public bool start = false;
    public float stärke;
    public float dauer;
    public float maxEntfernungZuStart;
    bool an = false;
    Vector3 startposition;

    // Update is called once per frame
    void Update()
    {

        if (start)
        {
            an = true;
            start = false;
            startposition = transform.position;
            StartCoroutine(beende_nach_sekunden(dauer));
        }

        if (an)
        {
            //Boden random wackeln lassen
            transform.position += new Vector3(0, Time.deltaTime * (float)(stärke * (Random.value-0.5)), 0);

            //Boden nicht zu weit von der Startposition abdriften lassen
            if ((transform.position - startposition).magnitude > maxEntfernungZuStart) transform.position = startposition;
        }
    }

    IEnumerator beende_nach_sekunden(float sekunden)
    {
        //Warte Sekunden
        yield return new WaitForSeconds(sekunden);

        //Wackeln beenden
        Debug.Log("beenden");
        an = false;

        //Startposition wiederherstellen
        transform.position = startposition;
    }
}
