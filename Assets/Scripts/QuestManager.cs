using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

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
    public InputField InputF;
    public GameObject Input;
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

    private bool isFalse = true;
    private string Qname;
    private string Qtext;

    public void DequeueQuest()
    {
        if(QuestInfo.Count == 4) //첫번째 퀘스트의 첫번째 문제
        {
            if(!isFalse)
            {
                dialogueName.text = Qname;
                dialogueText.text = Qtext;
                Input.SetActive(true);
            }

            if (InputF.text.ToString().Equals("8"))
            {
                
                QuestBase.Info info = QuestInfo.Dequeue();
                dialogueName.text = info.myName;
                dialogueText.text = info.myText;
            }
            else
            {
                dialogueName.text = null;
                dialogueText.text = "그곳이 아닌 것 같아!";
                InputF.text = null;
                Input.SetActive(false);
                isFalse = false;
                
            }
        }
        else if(QuestInfo.Count == 0)
        {
            EndofQuest();
            return;
        }
        else
        {
            
            QuestBase.Info info = QuestInfo.Dequeue();
            dialogueName.text = info.myName;
            dialogueText.text = info.myText;

            if (QuestInfo.Count == 4)
            {
                Input.SetActive(true);
                Qname = info.myName;
                Qtext = info.myText;
                //Debug.Log(Qname + Qtext);
            }
        }

    }

    public void EndofQuest()
    {
        QuestDialogBox.SetActive(false); //화면에서 없앰
        //Dialog.DequeueDialogue()
    }

}
