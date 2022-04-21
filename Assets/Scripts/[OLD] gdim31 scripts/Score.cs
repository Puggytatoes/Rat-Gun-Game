using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Don't forget this line
public class Score : MonoBehaviour
{
    public static int totalScore = 0;
    [SerializeField]
    private Text textElement;

    void Update()
    {
        totalScore = (GetCollected.numPizzas * 50) + (CockroachHealth.numCockroaches * 100);
        textElement.text = "Score: " + totalScore.ToString();
    }
}
