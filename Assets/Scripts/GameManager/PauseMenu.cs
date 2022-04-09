//Contributor(s): Simon Cho 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool m_IsPaused = false;  //set a boolean variable to check if the game is current pause or not
    public GameObject m_PauseMenuUI;        //get pausemenuUI in unity and attach it

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //when P key is pressed, execute Resume and Pause functions depending on the boolan variable called "m_isPaused"
        {
            if (m_IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        m_PauseMenuUI.SetActive(false);     //turn off the pause menu in unity
        Time.timeScale = 1f;        //bring the game back to the normal speed which is 1f
        m_IsPaused = false;     //set the boolean value to false
    }


    void Pause()
    {
        m_PauseMenuUI.SetActive(true); //turn on the pause menu in unity
        Time.timeScale = 0f;    //pause the game time
        m_IsPaused = true;  //set the boolean value to true
    }

    public void MainMenu()
    {
        Resume();   //call resume function
        GameManager.QuitToTitle(); //call quit to title function in GameStateManager and go back to the main menu
    }
}
