using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject glock;
    void Start()
    {
        GameObject.Find("TestRat").GetComponent<PlayerShoot>().enabled = false;
        glock = GameObject.Find("Glock");
        glock.SetActive(false);
    }
}
