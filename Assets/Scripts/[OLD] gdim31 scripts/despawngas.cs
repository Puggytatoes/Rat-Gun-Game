using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawngas : MonoBehaviour
{
        

    IEnumerator gas()
    {
        yield return new WaitForSeconds(1.05f);
        Destroy(gameObject);
        yield return new WaitForSeconds(1.45f);
    }
        
    void Update()
        
    {
        bool yes = true;
        if (yes == true)
        {
                
            StartCoroutine(gas());

        }
    }

}
