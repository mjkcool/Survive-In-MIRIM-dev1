﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class QuestStarter : MonoBehaviour
{
    public QuestBase[] quests = {};
    public GameObject splashImage;
    public Image IndexImage; //=splashImage
    public Sprite[] idxs = {}; //포트레잇 이미지(퀘스트 문제 이미지)
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
        switch (questnum)
        {
            case 1:
                Quest1Manager.instance.EnqueueQuest(quests[questnum - 1]);
                break;
            case 2:
                Quest2Manager.instance.EnqueueQuest(quests[questnum - 1]);
                break;
            case 3:
                Quest3Manager.instance.EnqueueQuest(quests[questnum - 1]);
                break;
            case 4:
                Quest4Manager.instance.EnqueueQuest(quests[questnum - 1]);
                break;
            case 5:
                Quest5Manager.instance.EnqueueQuest(quests[questnum - 1]);
                break;
            default: break;
        }
        
    }
}
