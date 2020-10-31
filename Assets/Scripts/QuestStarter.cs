using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStarter : MonoBehaviour
{
    public QuestBase quest;
    public GameObject splashImage;
    public GameObject QuestObject;

    public void start()
    {
        Invoke("splashIndex", 2f);
    }

    public void splashIndex()
    {
        splashImage.SetActive(true);
        Debug.Log("나타남");
        Invoke("TriggerDialogue", 3f);
    }

    public void TriggerDialogue()
    {
        Debug.Log("사라짐");
        Destroy(splashImage);
        QuestObject.SetActive(true);
        QuestManager.instance.EnqueueQuest(quest);
    }
}
