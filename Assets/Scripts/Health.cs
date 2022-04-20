using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health;

    [SerializeField]
    private int numOfHearts;

    private static int sHearts = 5;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        numOfHearts = sHearts;
        if (numOfHearts == 0)
        {
            StartCoroutine(WaitCoroutine());
            sHearts = 5;
            Score.totalScore = 0;
            GetCollected.numPizzas = 0;
            CockroachHealth.numCockroaches = 0;

        }
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public static void RemoveHeart()
    {
        sHearts -= 1;
    }
}