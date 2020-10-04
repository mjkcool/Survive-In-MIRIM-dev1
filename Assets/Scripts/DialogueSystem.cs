using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI txtName, txtSentence;

    Queue<string> names = new Queue<string>();
    Queue<string> sentences = new Queue<string>();

    public Animator anim;
    

    public void Begin(Dialogue info)
    {
        anim.SetBool("isOpened", true);
        names.Clear();
        sentences.Clear();

        foreach (var name in info.names)
        {
            names.Enqueue(name);
        }
        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Next();
        
    }

    public void Next()
    {
        Debug.Log("Next함수");
        if (sentences.Count == 0) End();

        txtName.text = names.Dequeue();
        txtSentence.text = sentences.Dequeue();
    }

    private void End()
    {
        Debug.Log("End of Chapter");
        anim.SetBool("isOpened", false);
    }

}
