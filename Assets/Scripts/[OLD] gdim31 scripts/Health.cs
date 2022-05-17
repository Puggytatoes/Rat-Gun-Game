using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
    public int health;

    [SerializeField]
    private int numOfHearts;

    private static int sHearts = 5;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Start()
    {
        sHearts = 5;
        Debug.Log("health" + health + " and sHearts" + sHearts);
        health = sHearts;
    }

    void Update()
    {
        
        health = sHearts;
        /*
        if (health == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            sHearts = 5;
        }*/
        
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
    public static void RemoveHeart()
    {
        sHearts -= 1;
    }

    public static void AddHeart()
    {
        sHearts += 1;
    }
    public static int GetHearts()
    {
        return sHearts;
    }
}