using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Alejandro
public class spawngas : MonoBehaviour
{
    public GameObject Gas;

    bool yes = true;

    public Transform spawnPoint;

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, Vector3.one);
    }

    IEnumerator gas()
    {
        yes = false;
        yield return new WaitForSeconds(1.05f);
        Instantiate(Gas, spawnPoint.position, spawnPoint.rotation);
        OnDrawGizmos();
        yield return new WaitForSeconds(1.45f);
        yes = true;
        
    }
    void FixedUpdate()
    {
        
        if (yes == true)
        {
            StartCoroutine(gas());
        }
    }
   
}