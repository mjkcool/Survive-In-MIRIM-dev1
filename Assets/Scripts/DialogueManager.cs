using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("fix this" + gameObject.name);
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
    public bool Q1completed = false, Q2completed = false;
    private int passed_dialognum;

    public void Start()
    {
        dialogueInfo = new Queue<DialogueBase.Info>();  //다이얼로그 초기화
    }


    public void EnqueueDialogue(DialogueBase db)
    {
        DialogueBox.SetActive(true); //화면에 띄움
        dialogueInfo.Clear();


        foreach (DialogueBase.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        dialogtotalcnt = dialogueInfo.Count;
        passed_dialognum = 13; //다음 퀘스트 시작 지점 지정

        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        if (dialogueInfo.Count == 0) //챕터 1 종료
        {
            EndofDialogue();
        }
        else if ((dialogueInfo.Count == (dialogtotalcnt - passed_dialognum)) && (!Q1completed)) //퀘스트 1 시작
        {
            passed_dialognum += 23;
            DialogueBox.SetActive(false);
            questStarter.questnum = 1;
            questStarter.start();
        }
        else if ((dialogueInfo.Count == (dialogtotalcnt - passed_dialognum)) && (!Q2completed)) //퀘스트 2 시작
        {
            passed_dialognum += 10;//값 임시
            DialogueBox.SetActive(false);
            questStarter.questnum = 2;
            Debug.Log("퀘스트2: "+ questStarter.questnum.ToString());
            questStarter.start();
        }

        if (isCurrentlyTyping == true)
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
        foreach (char c in info.myText.ToCharArray())
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
    }
}