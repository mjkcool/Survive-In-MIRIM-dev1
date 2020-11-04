using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private void Awake(){
        if(instance != null)
        {
            Debug.LogWarning("fix this"+gameObject.name);
        }
        else
        {
            instance = this;            
        }
    }
    
    public GameObject DialogueBox;
    public TextMeshProUGUI dialogueName;
    public TextMeshProUGUI dialogueText;
    public Image dialoguePortrait;
    public float delay = 2f;
    public QuestStarter questStarter;

    public bool isCurrentlyTyping;
    private string completeText;
    
    public Queue<DialogueBase.Info> dialogueInfo;

    private int dialogtotalcnt;

    


    public void Start()
    {
        dialogueInfo = new Queue<DialogueBase.Info>();  //다이얼로그 초기화
    }


    public void EnqueueDialogue(DialogueBase db)
    {
        DialogueBox.SetActive(true); //화면에 띄움
        dialogueInfo.Clear();


        foreach(DialogueBase.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        dialogtotalcnt = dialogueInfo.Count;
        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        if(dialogueInfo.Count==0) //챕터 1 종료
        {
            DialogueBox.SetActive(false);
        }
        else if(dialogueInfo.Count == dialogtotalcnt-13) //퀘스트 1 시작
        {
            DialogueBox.SetActive(false);
            questStarter.start();
        }

        if(isCurrentlyTyping == true)
        {
            CompleteText();
            StopAllCoroutines();
            isCurrentlyTyping = false;
            return;
        }

        DialogueBase.Info info = dialogueInfo.Dequeue();
        completeText = info.myText;

        dialogueName.text = info.myName;
        dialogueText.text = info.myText;
        dialoguePortrait.sprite = info.portrait;
    
        dialogueText.text = "";
        StartCoroutine(TypeText(info));
    }

    IEnumerator TypeText(DialogueBase.Info info)
    {
        isCurrentlyTyping = true;
        foreach(char c in info.myText.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;
        }
        isCurrentlyTyping = false;
    }

    private void CompleteText()
    {
        dialogueText.text = completeText;
    }

    
    public void EndofDialogue()
    {
        DialogueBox.SetActive(false); //화면에서 없앰
        questStarter.start();
    }
}
