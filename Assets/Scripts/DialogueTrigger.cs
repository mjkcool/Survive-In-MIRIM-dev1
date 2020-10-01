using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue info;

    public void Trigger()
    {
        info = new Dialogue();
        info.names = new List<string>();
        info.sentences = new List<string>();
        info.names.Add("유저");
        info.names.Add("영재");
        info.names.Add("유저");
        info.names.Add("영재");
        info.names.Add("");
        info.names.Add("박향규 선생님");
        info.names.Add("");
        info.names.Add("유저");
        info.names.Add("박향규");
        info.names.Add("유저");
        info.names.Add("");
        info.names.Add("유저");
        info.sentences.Add("오늘 시험 잘 볼 수 있을까?");
        info.sentences.Add("야! 너 되게 일찍 왔네. 공부 많이 했냐?");
        info.sentences.Add("했겠냐? 어제 겨우 밤샜다.");
        info.sentences.Add("나도 밤샘. 나 자신의 고뇌하는 모습을 연기연습하느라.");
        info.sentences.Add("어디선가 자신감이 솟구친다. 선생님이 들어오시고 시험지가 배부된다.");
        info.sentences.Add("학번이름부터 써라. 과목 코드는 01번이다. 알겠나?");
        info.sentences.Add("시험지를 본다.");
        info.sentences.Add("어? 선생님 저희 국어인데요? 시험지에 수학이라고 써있어요...");
        info.sentences.Add("뭐라고? 2학년 1일 1교시 시험지가 맞다. 조용히 해라.");
        info.sentences.Add("시험지에 문제가 있음이 분명해. 아씨 수학은 내일이라 오늘 벼락치기하려고 공부 하나도 안했는데...");
        info.sentences.Add("뒤를 돌아보니 친구들이 문제를 풀고 있다.");
        info.sentences.Add("무언가 잘못됐어! 내 스스로 해결해야 해.");

        var system = FindObjectOfType<DialogueSystem>();
        system.Begin(info);

    }

}
