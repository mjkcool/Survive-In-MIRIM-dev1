using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class QuestStarter : MonoBehaviour
{
    public QuestBase quest;
    public GameObject splashImage;
    public Image IndexImage; //=splashImage
    public Sprite[] idxs = {};
    public GameObject QuestObject;
    public int questnum;


    public void start()
    {
        Invoke("splashIndex", 2f);
    }

    public void splashIndex()
    {
        IndexImage.sprite = idxs[questnum-1];
        splashImage.SetActive(true); //퀘스트 인덱스 이미지
        Debug.Log("나타남");
        Invoke("TriggerDialogue", 3f);
    }

    public void TriggerDialogue()
    {
        
        Debug.Log("사라짐");
        splashImage.SetActive(false); //퀘스트 인덱스 이미지
        QuestObject.SetActive(true);
        Quest1Manager.instance.EnqueueQuest(quest);
    }
}
