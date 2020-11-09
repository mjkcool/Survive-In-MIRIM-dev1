﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Quest1Manager : MonoBehaviour
{
    //Dialog Objects
    public GameObject QuestDialogBox;
    public TextMeshProUGUI dialogueName;
    public TextMeshProUGUI dialogueText;
    public Image Portrait;
    public Sprite portraitImage;
    //Q1-1
    public InputField InputF_1;
    public GameObject Input_1;
    //Q1-2
    public InputField InputF_2;
    public GameObject Input_2;

    //anim
    public GameObject starAnimation;
    public GameObject LoadingAnimation;
    public GameObject LoadingGround;

    private int dialogtotalcnt;
    public Queue<QuestBase.Info> QuestInfo;

    public static Quest1Manager instance;

    public void Awake()
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

    public void Start()
    {
        QuestInfo = new Queue<QuestBase.Info>();  //초기화
    }

    public void EnqueueQuest(QuestBase db)
    {
        Portrait.sprite = portraitImage;
        //이미지 사이즈 지정
        RectTransform rt = (RectTransform)Portrait.transform;
        rt.sizeDelta = new Vector2(1048, 1400);
        QuestDialogBox.SetActive(true);
        QuestInfo.Clear();

        foreach (QuestBase.Info info in db.QuestInfo)
        {
            QuestInfo.Enqueue(info);
        }
        dialogtotalcnt = QuestInfo.Count;

        InputF_1.characterLimit = 2;
        InputF_2.characterLimit = 52;

        DequeueQuest();
    }

    private bool flag = true; //기본값은 true
    private QuestBase.Info Qinfo_1, Qinfo_2;

    public void DequeueQuest()
    {
        if (QuestInfo.Count == dialogtotalcnt-3)
        {
            if (!flag) //문제 틀린 직후
            {
                Input_1.SetActive(true);
                dialogueName.text = Qinfo_1.myName;
                dialogueText.text = Qinfo_1.myText;
                flag = true;
            }
            else //문제 답 입력
            {
                if ((InputF_1.text.ToString()).Equals("4"))
                {
                    QuestBase.Info info = QuestInfo.Dequeue();
                    dialogueName.text = info.myName;
                    dialogueText.text = info.myText;
                    Input_1.SetActive(false);
                }
                else if ((InputF_1.text.ToString()).Trim().Equals("") || (InputF_1.text.ToString()) == null)
                {
                    return; //미입력시 아무 반응 안함
                }
                else //오답 입력시
                {
                    Input_1.SetActive(false);
                    dialogueName.text = null;
                    dialogueText.text = "그곳이 아닌 것 같아!";
                    flag = false;
                }
            }
            InputF_1.text = null;
        }
        else if (QuestInfo.Count == dialogtotalcnt - 5)
        {
            if (!flag) //문제 틀린 직후
            {
                Input_2.SetActive(true);
                dialogueName.text = Qinfo_2.myName;
                dialogueText.text = null;
                flag = true;
            }
            else //문제 답 입력
            {
                if ((InputF_2.text.ToString()).Trim().Equals("") || (InputF_2.text.ToString()) == null) //
                {
                    return; //미입력시 아무 반응 안함
                }
                else
                {

                    QuestManager.instance.startLoading(isCorrect(InputF_2.text.ToString()));

                    if (isCorrect(InputF_2.text.ToString()))
                    {
                        //정답의경우

                        QuestBase.Info info = QuestInfo.Dequeue();
                        dialogueName.text = info.myName;
                        dialogueText.text = info.myText;
                        Input_2.SetActive(false);
                    }
                    else //오답 입력시
                    {
                        Input_2.SetActive(false);
                        dialogueName.text = null;
                        dialogueText.text = "잘못되었습니다";
                        flag = false;
                    }
                }
                
            }
        }
        else if (QuestInfo.Count == 0) //Quest 다이얼로그 끝나면
        {

            EndofQuest();
            return;
        }
        else
        {
            QuestBase.Info info = QuestInfo.Dequeue();
            if (QuestInfo.Count == dialogtotalcnt - 3) //input 1 최초 로드
            {
                Input_1.SetActive(true);
                Qinfo_1 = info;
            }
            else if (QuestInfo.Count == dialogtotalcnt - 5) //input 2 최초 로드 
            {
                Input_2.SetActive(true);
                Qinfo_2 = info;
            }
            dialogueName.text = info.myName;
            dialogueText.text = info.myText;
        }

    }

    private string Correct_answer = "= new File ( \"final+2semester+2020/Korean.pdf\" ) ;"; //= new File ( "final+2semester+2020/Korean.pdf" ) ;

    private bool isCorrect(string answer)
    {
        answer = answer.Trim();
        string[] answer_value = answer.Split('\x020');

        //전체 문자열이 다르면 오답
        if (!answer.Replace(" ", "").Equals(Correct_answer.Replace(" ", "")))
        {
            return false;
        }

        string[] raw_list = Correct_answer.Split('\x020');

        //필수 단어들이 들어가 있는지
        if (answer.IndexOf(raw_list[1]+" ") == -1 || answer.IndexOf(raw_list[2]) == -1 || answer.IndexOf(raw_list[4]) == -1)
        {
            return false;
        }

        //문자들의 위치 순서가 맞는지
        int pos = -1, nowpos;
        for(int i=0; i<raw_list.Length; i++)
        {
            nowpos = answer.IndexOf(raw_list[i]);
            if (nowpos > -1 && nowpos > pos)
            {
                pos = nowpos;
            }
            else
            {
                return false;
            }
        }

        return true;
    }


    private void EndofQuest()
    {
        Destroy(transform.Find("othertexts"));
        QuestDialogBox.SetActive(false);//화면에서 없앰
        DialogueManager.instance.Q1completed = true;
        (DialogueManager.instance.DialogueBox).SetActive(true);
        DialogueManager.instance.DequeueDialogue();
    }

}
