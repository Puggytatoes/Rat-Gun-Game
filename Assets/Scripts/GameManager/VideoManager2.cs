using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManager2 : MonoBehaviour
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
            SceneManager.LoadScene("MainMenu");
        }
    }

    void AfterVideo(VideoPlayer vp)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
