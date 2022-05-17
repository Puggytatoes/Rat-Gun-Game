using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;
    [SerializeField]private Health hl;
    private Animator anim;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (hl.health < 1)
        {
            StartCoroutine(GameoverCoroutine());
            

        }
    }

    private IEnumerator GameoverCoroutine()
    {
        yield return new WaitForSeconds(.8f);
        Score.totalScore = 0;
        GetCollected.numPizzas = 0;
        CockroachHealth.numCockroaches = 0;
        SceneManager.LoadScene("Game Over");
    }
}
