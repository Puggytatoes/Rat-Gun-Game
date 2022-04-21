using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawngas1 : MonoBehaviour
{
    public GameObject Gas;

    bool yes = true;

    public Transform spawnPoint;


        IEnumerator gas()
    {
        
        yes = false;
        yield return new WaitForSeconds(2.3f);
        Instantiate(Gas, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(.2f);
        yes = true;
        
    }
    void start()
    {
        
    }
    void Update()
    {
        
        if (yes == true)
        {
            
            StartCoroutine(gas());
        }
    }
   
}



    