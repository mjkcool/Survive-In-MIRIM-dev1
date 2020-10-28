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
    public InputField input1;
    public float delay = 2f;

    public Queue<QuestBase.Info> QuestInfo;

    public void Start()
    {
        Portrait.setActive(true);
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
    public void DequeueQuest()
    {
      
        if(QuestInfo.Count == 4) //첫번째 퀘스트의 첫번째 문제
        {
            if ((input1.text.ToString()).Equals(8))
            {
                QuestBase.Info info = QuestInfo.Dequeue();
                dialogueName.text = info.myName;
                dialogueText.text = info.myText;
            }
            else
            {
                dialogueName.text = null;
                dialogueText.text = "그곳이 아닌 것 같아!";
            }
        }
        else if(QuestInfo.Count == 0)
        {
            EndofQuest();
            return;
        }
        else
        {
            if (QuestInfo.Count == 5)
            {
                input1.setActive(true);
            }
            QuestBase.Info info = QuestInfo.Dequeue();
            dialogueName.text = info.myName;
            dialogueText.text = info.myText;

            dialogueName.text = "";
            dialogueText.text = "";
        }

    }

    public void EndofQuest()
    {
        QuestDialogBox.SetActive(false); //화면에서 없앰
        //Dialog.DequeueDialogue()
    }

}
