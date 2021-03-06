//Contributor(s): Simon Cho 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public void OnClickNewGame()
    {
        GameManager.NewGame(); //on clicking the assigned button, load a new game
        

    }

    public void OnClickRestart1()
    {
        GameManager.Restart1();
    }

    public void OnClickRestart2()
    {
        GameManager.Restart2();
    }


    public void OnMainMenu()
    {
        GameManager.QuitToTitle(); //on clicking the assigned button, load a new game
    }

    public void OnClickQuitGame()
    {
        Application.Quit(); //on clicking the assigned button, exit out of the game
    }

    public void OnReplayGame()
    {
        GameManager.Replay();
    }
}
