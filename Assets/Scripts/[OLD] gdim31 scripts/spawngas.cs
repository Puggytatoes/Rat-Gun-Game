using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Alejandro
public class spawngas : MonoBehaviour
{
    public GameObject Gas;

    bool yes = true;

    public Transform spawnPoint;

    IEnumerator gas()
    {
        yes = false;
        yield return new WaitForSeconds(1.05f);
        Instantiate(Gas, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(1.45f);
        yes = true;
        
    }
    void Update()
    {
        
        if (yes == true)
        {
            StartCoroutine(gas());
        }
    }
   
}



    