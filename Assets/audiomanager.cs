using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public static audiomanager instance;

    private void Awake()
    {
        instance = this;
    }

    public AudioClip scratch;
    public AudioClip damaged;
    public AudioClip walk;

    public GameObject soundobject;
   public void PlaySFX (string sfxName)
    {
        switch (sfxName)
        {
            case "scratch":
                SoundObjectCreation(scratch);
                break;
            case "damaged":
                SoundObjectCreation (damaged);
                break;
            

        }
    }

    void SoundObjectCreation(AudioClip clip)
    {
        GameObject newObject = Instantiate(soundobject, transform);
        newObject.GetComponent<AudioSource>().clip = clip;
        newObject.GetComponent<AudioSource>().Play();
    }
   
    void Update()
    {
        
    }
}
