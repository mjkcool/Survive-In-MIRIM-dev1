using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBoxCreater : MonoBehaviour {

    private void Awake()
    {
        Invoke("Create", 6f);
    }

    private void Create()
    {
        //대사 부여
        DialogueTrigger trigger = new DialogueTrigger();
        trigger.Trigger();
    }

}
