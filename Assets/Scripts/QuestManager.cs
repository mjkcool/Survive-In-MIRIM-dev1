using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

static class constVals{
    const int Q1_1_cnt = 5, Q1_2_cnt = 3;
}

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
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
    public InputField Q1_1_InputF;
    public GameObject Q1_1_Input;
    public InputField Q1_2_InputF;
    public GameObject Q1_2_Input;
    public float delay = 2f;

    public Queue<QuestBase.Info> QuestInfo;

    public void Start()
    {
        QuestInfo = new Queue<QuestBase.Info>();  //초기화
    }

    public void EnqueueQuest(QuestBase db)
    {
        QuestDialogBox.SetActive(true);
        QuestInfo.Clear();

        foreach(QuestBase.Info info in db.QuestInfo)
        {
            QuestInfo.Enqueue(info);
        }
        DequeueQuest();
    }

    private bool flag = true; //기본값은 true
    private QuestBase.Info Q1_1;

    public void DequeueQuest()
    {
        //----------------------------------------------------------------
        //Q1-1
        if (QuestInfo.Count == constVals.Q1_1_cnt)
        {  
            if (!flag)
            {
                Q1_1_Input.SetActive(true);
                dialogueName.text = Q1_1.myName;
                dialogueText.text = Q1_1.myText;
                flag = true;
            }
            else
            {
                if ((Q1_1_InputF.text.ToString()).Equals("4"))
                {
                    QuestBase.Info info = QuestInfo.Dequeue();
                    dialogueName.text = info.myName;
                    dialogueText.text = info.myText;
                    Q1_1_Input.SetActive(false);
                }
                else if ((Q1_1_InputF.text.ToString()).Equals(""))
                {
                    return;
                }
                else
                {
                    Q1_1_Input.SetActive(false);
                    dialogueName.text = null;
                    dialogueText.text = "그곳이 아닌 것 같아!";
                    flag = false;
                }
            }
        }
        else if(QuestInfo.Count == 0) //Quest 다이얼로그 끝나면
        {
            EndofQuest();
            return;
        }
        else
        {
            QuestBase.Info info = QuestInfo.Dequeue();
            if (QuestInfo.Count == constVals.Q1_1_cnt)
            {
                Q1_1_Input.SetActive(true);
                Q1_1 = info;
            }
            dialogueName.text = info.myName;
            dialogueText.text = info.myText;
        }//end of Q1-1

        //----------------------------------------------------------------
        //Q1-2
        if (QuestInfo.Count == constVals.Q1_2_cnt)
        {
            if (!flag)
            {
                Q1_2_Input.SetActive(true);
                dialogueName.text = Q1_2.myName;
                dialogueText.text = Q1_2.myText;
                flag = true;
            }
            else
            {
                if ((Q1_2_InputF.text.ToString()).Equals(""))
                {
                    QuestBase.Info info = QuestInfo.Dequeue();
                    dialogueName.text = info.myName;
                    dialogueText.text = info.myText;
                    Q1_2_Input.SetActive(false);
                }
                else if ((Q1_2_InputF.text.ToString()).Equals(""))
                {
                    return;
                }
                else
                {
                    Q1_2_Input.SetActive(false);
                    dialogueName.text = null;
                    dialogueText.text = "그곳이 아닌 것 같아!";
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
            if (QuestInfo.Count == 5)
            {
                Q1_2_Input.SetActive(true);
                Q1_1 = info;
            }
            dialogueName.text = info.myName;
            dialogueText.text = info.myText;
        }//end of Q1-2

    }

    
    public void EndofQuest()
    {
        QuestDialogBox.SetActive(false); //화면에서 없앰
        //Dialog.DequeueDialogue()
    }

}
