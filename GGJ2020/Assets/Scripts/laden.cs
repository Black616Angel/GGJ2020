using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class laden : MonoBehaviour
{
    public void LadeSzene(int buildindex)
    {
        //Application.LoadLevel(buildid);
        SceneManager.LoadScene(buildindex);
    }
}
