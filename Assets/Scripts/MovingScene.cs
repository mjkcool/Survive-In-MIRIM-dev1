using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class MovingScene : MonoBehaviour
{
    public TMP_InputField UserName;
    public int NextSceneNumber;
    
    // Start is called before the first frame update
    public void move()
    {
        SceneManager.LoadScene(NextSceneNumber);
    }

    public int nowQuestNum;
    public void goHome()
    {
        PopupBuilder popupBuilder = new PopupBuilder(this.transform);
        popupBuilder.SetTitle("챕터 목록으로 이동");
        popupBuilder.SetDescription("[챕터"+ nowQuestNum+"]을 종료하시겠습니까 ? ");
        // 버튼은 왼쪽부터 생성된다, 아무기능 없을때는 2번째 매개변수 작성 x
        popupBuilder.SetButton("예"/*, move()*/);
        popupBuilder.SetButton("아니오");
        popupBuilder.Build();
    }

    public void setUsername()
    {
        string name;
        if((UserName.text.ToString()).Length == 0 || UserName.text.ToString() == null) name = "User";
        else name = UserName.text.ToString();
        DialogueManager.UserName = name;
        Debug.Log("유저내임 첨 입력: " + DialogueManager.UserName);
    }

}
