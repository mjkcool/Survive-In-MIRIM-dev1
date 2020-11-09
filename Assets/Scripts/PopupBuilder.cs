using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PopupBuilder : MonoBehaviour
{
    private Transform target = null;
    // Build메소드 호출할때 팝업창을 꾸며주기 위한 멤버변수 
    private string title = null;
    private string description = null;
    private List<PopupButtonInfo> buttonInfoList = null;
    // 생성자에서 부모타겟 매개변수로 가져온다. 
    public PopupBuilder(Transform _target) {
        this.target = _target;
        this.buttonInfoList = new List<PopupButtonInfo>();
    }
    public void Build() {
        // 최종적으로 모든정보를 가지고 팝업창생성 
        // MonoBehaviour의 제거로 인해 Instantiate을 사용불가, 
        // 프리팹생성을 위해 GameObject의 static메소드로 호출 
        GameObject popupObject = GameObject.Instantiate(Resources.Load("Popup/" + "PopupPanel", typeof(GameObject))) as GameObject;
        popupObject.transform.SetParent(this.target, false);
        PopupPanel popupPanel = popupObject.GetComponent<PopupPanel>(); // 팝업설정 
        popupPanel.setTitle(this.title);
        popupPanel.setDescription(this.description);
        popupPanel.setButtons(this.buttonInfoList); popupPanel.Init();
    }
    public void SetTitle(string _title) {
        // 타이틀정보 초기화 
        this.title = _title;
    }
    public void SetDescription(string _description) {
        // 설명정보 초기화 
        this.description = _description;
    }
    public void SetButton(string _text, CallbackEvent _callback = null) { 
        // 버튼정보 초기화 - 호출할때마다 버튼 하나씩 추가 
        this.buttonInfoList.Add(new PopupButtonInfo(_text, _callback));
    }
}
