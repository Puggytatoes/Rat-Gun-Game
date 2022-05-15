using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawngasanimation : MonoBehaviour
{
    public GameObject Gasani;

    bool yes = false;

    public Transform spawnPoint;


    IEnumerator gas()
    {

        yield return new WaitForSeconds(2.5f);
        Instantiate(Gasani, spawnPoint.position, spawnPoint.rotation);


    }
    void Update()
    {

        if (yes == false)
        {
            StartCoroutine(gas());
            yes = true;
        }
    }

}