using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;


public class Quest1Manager : MonoBehaviour
{
    private const int Q1_1_cnt = 5, Q1_2_cnt = 3;

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

    public GameObject QuestDialogBox;
    public TextMeshProUGUI dialogueName;
    public TextMeshProUGUI dialogueText;
    public Image Portrait;

    //Q1-1
    public InputField Q1_1_InputF;
    public GameObject Q1_1_Input;
    //Q1-2
    public InputField Q1_2_InputF;
    public GameObject Q1_2_Input;

    private string Q1_2_CorrectA_str = "=new File(“final+2semester+2020/Korean.pdf”);";


    public Queue<QuestBase.Info> QuestInfo;

    public void Start()
    {
        QuestInfo = new Queue<QuestBase.Info>();  //초기화
    }

    public void EnqueueQuest(QuestBase db)
    {
        QuestDialogBox.SetActive(true);
        QuestInfo.Clear();

        foreach (QuestBase.Info info in db.QuestInfo)
        {
            QuestInfo.Enqueue(info);
        }
        DequeueQuest();
    }

    private bool flag = true; //기본값은 true
    private QuestBase.Info Q1_1, Q1_2;

    public void DequeueQuest()
    {
        if (QuestInfo.Count == Q1_1_cnt)
        {
            if (!flag) //문제 틀린 직후
            {
                Q1_1_Input.SetActive(true);
                dialogueName.text = Q1_1.myName;
                dialogueText.text = Q1_1.myText;
                flag = true;
            }
            else //문제 답 입력
            {
                if ((Q1_1_InputF.text.ToString()).Equals("4"))
                {
                    QuestBase.Info info = QuestInfo.Dequeue();
                    dialogueName.text = info.myName;
                    dialogueText.text = info.myText;
                    Q1_1_Input.SetActive(false);
                }
                else if ((Q1_1_InputF.text.ToString()).Trim().Equals("") || (Q1_1_InputF.text.ToString()) == null)
                {
                    return; //미입력시 아무 반응 안함
                }
                else //오답 입력시
                {
                    Q1_2_InputF.text = null;
                    Q1_1_Input.SetActive(false);
                    dialogueName.text = null;
                    dialogueText.text = "그곳이 아닌 것 같아!";
                    flag = false;
                }
            }
        }
        else if (QuestInfo.Count == Q1_2_cnt)
        {
            if (!flag) //문제 틀린 직후
            {
                Q1_2_Input.SetActive(true);
                dialogueName.text = Q1_2.myName;
                dialogueText.text = null;
                flag = true;
            }
            else //문제 답 입력
            {
                if ((Q1_2_InputF.text.ToString()).Trim().Equals("") || (Q1_2_InputF.text.ToString()) == null) //
                {
                    return; //미입력시 아무 반응 안함
                }
                else if (isCorrect(Q1_2_InputF.text.ToString()))
                {
                    //정답의경우
                    QuestBase.Info info = QuestInfo.Dequeue();
                    dialogueName.text = info.myName;
                    dialogueText.text = info.myText;
                    Q1_2_Input.SetActive(false);
                }
                else //오답 입력시
                {
                    Q1_2_Input.SetActive(false);
                    dialogueName.text = null;
                    dialogueText.text = "잘못되었습니다";
                    flag = false;
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
            if (QuestInfo.Count == Q1_1_cnt) //문제 최초 로드
            {
                Q1_1_Input.SetActive(true);
                Q1_1 = info;
            }
            else if (QuestInfo.Count == Q1_2_cnt)
            {
                Q1_2_Input.SetActive(true);
                Q1_2 = info;
            }
            dialogueName.text = info.myName;
            dialogueText.text = info.myText;
        }//end of Q1-1

    }

    private bool isCorrect(string answer)
    {
        //= new File("final+2semester+2020/Korean.pdf");

        answer = answer.Trim();

        string total = answer.Replace(" ", "");
        string[] value = answer.Split('\x020');

        if (!total.Equals(Q1_2_CorrectA_str.Replace(" ", ""))) return false;
        for (int i = 0; i < value.Length; i++)
        {
            if (Q1_2_CorrectA_str.Contains(value[i]))
            {
                return false;
            }
        }
        return true;
    }

    public GameObject star;

    public void EndofQuest()
    {
        QuestDialogBox.SetActive(false);//화면에서 없앰
        DialogueManager.instance.Q1completed = true;
        (DialogueManager.instance.DialogueBox).SetActive(true);
        DialogueManager.instance.DequeueDialogue();
    }
}
