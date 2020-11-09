using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class PopupPanel : MonoBehaviour
{ 
    [SerializeField] // 제목 text오브젝트
    private Text titleText = null;
    [SerializeField] // 설명 text오브젝트
    private Text descriptionText = null;
    [SerializeField]// 버튼생성시 버튼들의 부모, 레이아웃을 사용해 생성시마다 위치를 잡아준다
    private GameObject buttonsLayout = null;

    // 버튼 프리팹
    [SerializeField]
    private GameObject buttonPrefab = null;

    public void Init()
    {

    }

    public void setTitle(string title)
    {
        this.titleText.text = title;
    }
    public void setDescription(string descipt)
    {
        this.descriptionText.text = descipt;
    }
    public void setButtons(List<PopupButtonInfo> popupButtonInfos)
    {
        foreach(var info in popupButtonInfos)
        {
            GameObject buttonObject = Instantiate(this.buttonPrefab);
            buttonObject.transform.SetParent(this.buttonsLayout.transform, false);
            PopupButton popupButton = buttonObject.GetComponent<PopupButton>();

            popupButton.Init(info.text, info.callback, this.gameObject);
        }
    }

}
