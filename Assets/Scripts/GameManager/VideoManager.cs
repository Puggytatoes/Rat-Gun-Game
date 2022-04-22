using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        VideoPlayer.loopPointReached += AfterVideo;
    }


    void AfterVideo(VideoPlayer vp)
    {
        SceneManager.LoadScene("SampleScene");
    }
}
