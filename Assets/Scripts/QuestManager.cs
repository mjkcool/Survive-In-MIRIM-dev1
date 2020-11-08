using System;
using UnityEngine;
using System.Globalization;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
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

    public void DelaySystem(int MS) //시간 지연 함수
    {
        /*DateTime dtAfter = DateTime.Now;
        TimeSpan dtDuration = new TimeSpan(0, 0, 0, 0, MS);
        DateTime dtThis = dtAfter.Add(dtDuration);

        while (dtThis >= dtAfter)
        {
            dtAfter = DateTime.Now;
        }*/
        //딜레이함수가 작동을 안함
    }

    //anim
    public GameObject QuestObj;
    public GameObject starAnimation;
    public GameObject LoadingAnimation;
    public GameObject LoadingGround;
    public GameObject success, failure;

    private bool correct;

    public void startLoading(bool correct)
    {
        QuestObj.SetActive(false);
        this.correct = correct;
        LoadingGround.SetActive(true);
        LoadingAnimation.SetActive(true);
        Invoke("showResult", 4f);
        QuestObj.SetActive(true);
    }
    private void showResult()
    {
        LoadingAnimation.SetActive(false);
        if (correct) success.SetActive(true);
        else failure.SetActive(true);
        
        Invoke("backToDialog", 2f);
    }
    private void backToDialog()
    {
        success.SetActive(false); failure.SetActive(false);
        LoadingGround.SetActive(false);
    }
}
