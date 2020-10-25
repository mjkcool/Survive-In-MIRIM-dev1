using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStarter : MonoBehaviour
{
    public QuestBase quest;
    public GameObject splashImage;

    public void splashIndex()
    {
        splashImage.SetActive(true);
        Invoke("TriggerDialogue", 3f);
    }

    public void TriggerDialogue()
    {
        splashImage.SetActive(false);
        //QuestManager.instance.EnqueueQuest(quest);
    }
}
