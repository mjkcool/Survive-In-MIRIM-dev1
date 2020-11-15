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
<<<<<<< HEAD
    private Animator animator;
    private AudioSource audio;
=======
>>>>>>> parent of 30c95d0... It can be build well, all of functions and process work

    private void Awake()
    {
        Debug.Log(Screen.width);
<<<<<<< HEAD
        //아이디 값이 0, 즉 세이브가 없는 경우
        if (DialogueManager.instance.thisId == 0)
        {
            chapterIndex.SetActive(true);
            Invoke("TriggerDialogue", 5f);
        }
        //퀘스트 중에 세이브했을 경우
        else if (DialogueManager.instance.thisId == 12)
        {
            GetComponent<AudioSource>().Stop();
            DialogueManager.instance.QuestDialogue(dialogue);
        }
        else if (DialogueManager.instance.thisId == 36)
        {
            GetComponent<AudioSource>().Stop();
            DialogueManager.instance.QuestDialogue(dialogue);
        }
        else if (DialogueManager.instance.thisId == 61)
        {
            GetComponent<AudioSource>().Stop();
            DialogueManager.instance.QuestDialogue(dialogue);
        }
        else if (DialogueManager.instance.thisId == 82)
        {
            GetComponent<AudioSource>().Stop();
            DialogueManager.instance.QuestDialogue(dialogue);
        }
        else if (DialogueManager.instance.thisId == 108)
        {
            GetComponent<AudioSource>().Stop();
            DialogueManager.instance.QuestDialogue(dialogue);
        }
        //일반적인 다이얼로그에서 세이브했을경우
        else
        {
            GetComponent<AudioSource>().Stop();
            DialogueManager.instance.LoadDialogue(dialogue);
        }
=======
        
        Invoke("TriggerDialogue", 5f);
>>>>>>> parent of 30c95d0... It can be build well, all of functions and process work
    }

    public void TriggerDialogue()
    {
        chapterIndex.SetActive(false);
        DialogueManager.instance.EnqueueDialogue(dialogue);
    }

}
