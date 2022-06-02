using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OpeningDialogue : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] TextMeshProUGUI textdisplay;
    [SerializeField] private string[] Sentences;
    int index;

    [SerializeField] private float Speed;
    void Start()
    {
        StartCoroutine(Dialogue_Text());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Dialogue_Text()
    {
        WaitForSeconds Wait = new WaitForSeconds(Speed);

        for(int i = 0; i < Sentences.Length-1; i++)
        {
            if(index == Sentences.Length - 1)
            {
                textdisplay.text = "";
                textdisplay.enabled = false;
            }
            else
            {
                index += 1;
                textdisplay.text = Sentences[index];
                textdisplay.enabled = true;
                yield return Wait;
                textdisplay.text = "";
            }
        }
    }
}
