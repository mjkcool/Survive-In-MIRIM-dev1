using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DialogStarter : MonoBehaviour
{
    public DialogueBase dialogue;
    public GameObject chapterIndex;

    private void Awake()
    {
        Debug.Log(Screen.width);
        //RectTransform rt = (RectTransform)GameObject.Find("Canvas").transform;
        //rt.sizeDelta = new Vector2(Screen.width, /*rt.sizeDelta.y*/Screen.height);
        //Screen.SetResolution(Screen.width, Screen.width * 16/9, true);
        //Screen.SetResolution(int width, int height, bool fullscreen);

        Invoke("TriggerDialogue", 5f);
    }

    public void TriggerDialogue()
    {
        chapterIndex.SetActive(false);
        DialogueManager.instance.EnqueueDialogue(dialogue);
    }
}
