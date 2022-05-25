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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("Level2Cutscene");
        }
    }

    void AfterVideo(VideoPlayer vp)
    {
        SceneManager.LoadScene("Level2Cutscene");
    }
}
