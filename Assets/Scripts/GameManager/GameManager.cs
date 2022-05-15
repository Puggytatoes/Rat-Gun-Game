//Contributor(s): Simon Cho 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<string> m_Levels = new List<string>();        //SerializeField these variables to assign levle, title scene, and win scene in unity
    [SerializeField] private string m_TitleSceneName;

    private static GameManager _instance;  //instantiate GameStateManger

    private void Awake()    //execute this function when the scene is called
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.QuitToTitle();     //execute QuitToTile function when ESC key is pressed
        }
        if (Input.GetKeyDown(KeyCode.R))    //press R key to restart the current scene
        {
            GameManager.Restart();
        }
    }

    public static void NewGame()
    {
        //PlayerPrefs.DeleteAll();        //reset playerprefs and start a new game
        if (_instance.m_Levels.Count > 0)       // whene there is at least 1 level, load 2nd ([1] in the list) scene
        {
            SceneManager.LoadScene(_instance.m_Levels[1]);
        }
    }

    public static void skipping()
    {
        SceneManager.LoadScene(_instance.m_Levels[2]);    //press K key to skip the prologue scene
    }

    public static void QuitToTitle()    //returning to the title
    {
        SceneManager.LoadScene(_instance.m_Levels[0]); //loads the title scene 
    }

    public static void Replay()    //returning to the title
    {
        SceneManager.LoadScene(_instance.m_Levels[2]); //loads the title scene 
    }

    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //restart the currently activated scene
    }
}