using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;
    [SerializeField]private Health hl;
    private Animator anim;
    public string currLevel;
    

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
        currLevel = SceneManager.GetActiveScene().name;
    }


    void Update()
    {
        currLevel = SceneManager.GetActiveScene().name;
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (hl.health < 1)
        {
            StartCoroutine(GameoverCoroutine());
            currLevel = SceneManager.GetActiveScene().name;
        }
    }

    private IEnumerator GameoverCoroutine()
    {
        Debug.Log(currLevel);
        yield return new WaitForSeconds(.8f);
        Score.totalScore = 0;
        GetCollected.numPizzas = 0;
        CockroachHealth.numCockroaches = 0;

        if (currLevel == "Level2")
        {
            SceneManager.LoadScene("Game Over2");
        }

        if (currLevel == "TestScene2")
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
