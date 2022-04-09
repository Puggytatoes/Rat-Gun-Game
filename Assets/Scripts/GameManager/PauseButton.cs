//Contributor(s): Simon Cho 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public static bool m_IsPaused = false;  //set a boolean variable to check if the game is current pause or not
    public GameObject m_PauseMenuUI;        //get pausemenuUI in unity and attach it

    public void OnClickPauseButton()
    {
        m_PauseMenuUI.SetActive(true); //turn on the pause menu in unity
        Time.timeScale = 0f;    //pause the game time
        m_IsPaused = true;  //set the boolean value to true
    }

}
