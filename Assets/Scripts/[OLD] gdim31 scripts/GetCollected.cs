using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GetCollected : MonoBehaviour
{
    public static int numPizzas;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            numPizzas += 1;
            Debug.Log("Number of Pizzas: " + numPizzas);
            Health.AddHeart();
        }
    }
}