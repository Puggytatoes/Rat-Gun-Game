using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxManager : MonoBehaviour
{

    public AudioSource sfx;

    public AudioClip walk;

    public static sfxManager sfxInstance;

    private void Awake()
    {
        if (sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        

        sfxInstance = this;
        DontDestroyOnLoad(this);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
