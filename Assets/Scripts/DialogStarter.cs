using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogStarter : MonoBehaviour
{
    public DialogueBase dialogue;
    public GameObject chapterIndex;

    private void Awake()
    {
        Invoke("TriggerDialogue", 5f);
    }

    public void TriggerDialogue()
    {
        Destroy(chapterIndex);
        DialogueManager.instance.EnqueueDialogue(dialogue);
    }
}
