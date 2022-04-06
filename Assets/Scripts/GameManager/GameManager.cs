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
    private static GAMESTATE m_State;          //assign gamestates of the game

    enum GAMESTATE  //List of gamestates
    {
        MENU,
        PLAYING,
        LOSING,
        RESTART,
        PAUSED,
        GAMEOVER,
        WIN
    }

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
        m_State = GAMESTATE.PLAYING;
        PlayerPrefs.DeleteAll();        //reset playerprefs and start a new game
        if (_instance.m_Levels.Count > 0)       // whene there is at least 1 level, load 2nd ([1] in the list) scene
        {
            SceneManager.LoadScene(_instance.m_Levels[1]);
        }
    }

    public static void QuitToTitle()    //returning to the title
    {
        m_State = GAMESTATE.MENU;
        SceneManager.LoadScene(_instance.m_Levels[0]); //loads the title scene 
    }

    public static void Restart()
    {
        m_State = GAMESTATE.RESTART;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //restart the currently activated scene
    }
}