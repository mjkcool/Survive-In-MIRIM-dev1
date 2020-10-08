using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogStarter : MonoBehaviour
{
    public DialogueBase dialogue;

    private void Awake()
    {
        Invoke("TriggerDialogue", 6f);
    }

    public void TriggerDialogue()
    {
        DialogueManager.instance.EnqueueDialogue(dialogue);
    }
}
