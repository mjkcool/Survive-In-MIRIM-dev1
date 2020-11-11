﻿using System.Collections;
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

    public static string UserName = "User";

    public AudioClip classSound;
    public AudioClip paperSound;
    public AudioClip schoolRingSound;

    public GameObject DialogueBox;
    public TextMeshProUGUI dialogueName;
    public TextMeshProUGUI dialogueText;
    public Image dialoguePortrait;
    public Image backgroundPortrait;
    private bool delay = false;
    public QuestStarter questStarter;
    public DialogueButton DialogBtn;

    public bool isCurrentlyTyping;
    private string completeText;

    public Queue<DialogueBase.Info> dialogueInfo;

    //오디오 
    public int classSound_dialog;
    public int classSoundEnd_dialog;
    public int firstExampaper_dialog;
    public int firstExampaperEnd_dialog;
    public int schoolRing_dialog;
    public int schoolRingEnd_dialog;
    //

    private int dialogtotalcnt;
    public bool Q1completed = false, Q2completed = false, Q3completed = false, Q4completed = false, Q5completed=false;
    private int passed_dialognum;
    private AudioSource audio; //사용할 오디오 소스 컴포넌트

    public void Start()
    {
        audio = GetComponent<AudioSource>();
        dialogueInfo = new Queue<DialogueBase.Info>();  //다이얼로그 초기화
    }


    public void EnqueueDialogue(DialogueBase db)
    {
        DialogueBox.SetActive(true); //화면에 띄움
        dialogueInfo.Clear();

        int i = 0;
        foreach (DialogueBase.Info info in db.dialogueInfo)
        {
            info.id = i++;
            dialogueInfo.Enqueue(info);
        }

        dialogtotalcnt = dialogueInfo.Count;
        classSound_dialog = 1;
        classSoundEnd_dialog = 5;
        firstExampaper_dialog = 8;
        firstExampaperEnd_dialog = 9;
        schoolRing_dialog = 14;
        schoolRingEnd_dialog = 15;

        passed_dialognum = 13; //다음 퀘스트 시작 지점 지정
        
        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        if (delay)
        {
            delayDialog();
            return;
        }

        lock (dialogueInfo)
        {
            if (dialogueInfo.Count == 0) //챕터 1 종료
            {
                EndofDialogue();
            }
            else if ((dialogueInfo.Count == (dialogtotalcnt - passed_dialognum)) && (!Q1completed)) //퀘스트 1 시작
            {
                passed_dialognum += 24;
                DialogueBox.SetActive(false);
                DialogBtn.questnum = 1;
                questStarter.questnum = 1;
                questStarter.start();
            }
            else if ((dialogueInfo.Count == (dialogtotalcnt - passed_dialognum)) && (!Q2completed)) //퀘스트 2 시작
            {
                passed_dialognum += 25;
                DialogueBox.SetActive(false);
                DialogBtn.questnum = 2;
                questStarter.questnum = 2;
                questStarter.start();
            }
            else if ((dialogueInfo.Count == (dialogtotalcnt - passed_dialognum)) && (!Q3completed))//퀘스트 3 시작
            {
                passed_dialognum += 21;
                DialogueBox.SetActive(false);
                DialogBtn.questnum = 3;
                questStarter.questnum = 3;
                questStarter.start();
            }
            else if ((dialogueInfo.Count == (dialogtotalcnt - passed_dialognum)) && (!Q3completed))//퀘스트 4 시작
            {
                passed_dialognum += 26;
                DialogueBox.SetActive(false);
                DialogBtn.questnum = 4;
                questStarter.questnum = 4;
                questStarter.start();
            }
            else if ((dialogueInfo.Count == (dialogtotalcnt - passed_dialognum)) && (!Q3completed))//퀘스트 5 시작
            {
                DialogueBox.SetActive(false);
                DialogBtn.questnum = 5;
                questStarter.questnum = 5;
                questStarter.start();
            }

            if (isCurrentlyTyping == true)
            {
                CompleteText();
                StopAllCoroutines();
                isCurrentlyTyping = false;
                return;
            }


            DialogueBox.SetActive(true);

            DialogueBase.Info info = dialogueInfo.Dequeue();
            completeText = info.myText;

            //유저 이름
            if(info.myName.Equals("유저")) dialogueName.text = UserName;
            else dialogueName.text = info.myName;

            dialogueText.text = info.myText.Replace("유저", UserName);
            dialoguePortrait.sprite = info.portrait;
            backgroundPortrait.sprite = info.background;

            delay = false;
            switch (info.id)
            {
                case 4: case 14: case 19: case 22: case 29: case 43: case 57: case 66: case 73: case 79: case 85:
                    delay = true;
                    break;
                default: break;
            }


            ////////오디오 설정
            if (dialogueInfo.Count == dialogtotalcnt - classSound_dialog)
            {
                GetComponent<AudioSource>().clip = classSound;
                GetComponent<AudioSource>().Play();
            }
            else if (dialogueInfo.Count < dialogtotalcnt - classSoundEnd_dialog)
            {
                GetComponent<AudioSource>().Stop();
            }

            if (dialogueInfo.Count == dialogtotalcnt - firstExampaper_dialog)
            {
                GetComponent<AudioSource>().clip = paperSound;
                GetComponent<AudioSource>().Play();
            }
            else if (dialogueInfo.Count == dialogtotalcnt - firstExampaperEnd_dialog)
            {
                GetComponent<AudioSource>().Stop();
            }

            if (dialogueInfo.Count == dialogtotalcnt - schoolRing_dialog)
            {
                GetComponent<AudioSource>().clip = schoolRingSound;
                GetComponent<AudioSource>().Play();
            }
            else if (dialogueInfo.Count == dialogtotalcnt - schoolRingEnd_dialog)
            {
                GetComponent<AudioSource>().Stop();
            }
            //

            dialogueText.text = "";
            StartCoroutine(TypeText(info));
        }

    }

    IEnumerator TypeText(DialogueBase.Info info)
    {
        isCurrentlyTyping = true;
        foreach (char c in info.myText.ToCharArray())
        {
            yield return new WaitForSeconds(2f);
            dialogueText.text += c;
        }
        isCurrentlyTyping = false;
    }

    private void CompleteText()
    {
        dialogueText.text = completeText;
    }

    private void EndofDialogue()
    {
        DialogueBox.SetActive(false); //화면에서 없앰
    }

    //대사 2초 자동 뜸들이기 함수
    private void delayDialog()
    {
        DialogueBox.SetActive(false);
        Invoke("DequeueDialogue", 2f);
    }
    
}