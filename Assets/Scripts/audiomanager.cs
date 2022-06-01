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
    public AudioClip sewers;
    public AudioClip roachdie;
    public AudioClip ratjump;
    public AudioClip yummy;
    public AudioClip startgunshot;

    public GameObject soundobject;

    /*public GameObject currentmusicobject;*/

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
            case "walk":
                SoundObjectCreation(walk);
                break;
            case "roachdie":
                SoundObjectCreation(roachdie);
                break;
            case "ratjump":
                SoundObjectCreation(ratjump);
                break;
            case "yummy":
                SoundObjectCreation(yummy);
                break;
            case "startgunshot":
                SoundObjectCreation(startgunshot);
                break;
        }
    }

  
    void SoundObjectCreation(AudioClip clip)
    {
        GameObject newObject = Instantiate(soundobject, transform);
        newObject.GetComponent<AudioSource>().clip = clip;
        newObject.GetComponent<AudioSource>().Play();
    }

    public void PlayMusic(string musicName)
    {
        switch (musicName)
        {
            case "sewers":
                SoundObjectCreation(sewers);
                break;

        }
    }

    void MusicObjectCreation(AudioClip clip)
    {
       /* if (currentmusicobject)
            Destroy(currentmusicobject); */
        GameObject newObject = Instantiate(soundobject, transform);
        newObject.GetComponent<AudioSource>().clip = clip;
        newObject.GetComponent<AudioSource>().loop = true;
        newObject.GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        
    }
}
