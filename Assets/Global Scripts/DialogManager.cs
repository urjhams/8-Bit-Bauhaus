using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startDialog(ObjectDialog dialog)
    {
        sentences.Clear();
        foreach (string sentence in sentences)
        {
            sentences.Enqueue(sentence);
        }
    }
    public void displayNextSentence()
    {
        if (sentences.Count == 0)
        {
            endDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        print(sentence);
    }

    void endDialog()
    {

    }
}
