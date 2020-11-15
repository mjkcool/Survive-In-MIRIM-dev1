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
    private Animator animator;


    private void Start()
    {
        Debug.Log(Screen.width);
        //아이디 값이 0, 즉 세이브가 없는 경우
        if (DialogueManager.instance.thisId == 0)
        {
            chapterIndex.SetActive(true);
            //GetComponent<AudioSource>().clip = DialogueManager.instance.schoolRingSound;
            //GetComponenst<AudioSource>().Play();
            Invoke("TriggerDialogue", 5f);
        }
        //퀘스트 중에 세이브했을 경우
        else if (DialogueManager.instance.thisId == 12)
        {
            DialogueManager.instance.QuestDialogue(dialogue);
        }
        else if (DialogueManager.instance.thisId == 36)
        {
            DialogueManager.instance.QuestDialogue(dialogue);
        }
        else if (DialogueManager.instance.thisId == 61)
        {
            DialogueManager.instance.QuestDialogue(dialogue);
        }
        else if (DialogueManager.instance.thisId == 82)
        {
            DialogueManager.instance.QuestDialogue(dialogue);
        }
        else if (DialogueManager.instance.thisId == 108)
        {
            DialogueManager.instance.QuestDialogue(dialogue);
        }
        //일반적인 다이얼로그에서 세이브했을경우
        else
        {
            DialogueManager.instance.LoadDialogue(dialogue);
        }
    }

    public void TriggerDialogue()
    {
        chapterIndex.SetActive(false);
        DialogueManager.instance.EnqueueDialogue(dialogue);
    }

}