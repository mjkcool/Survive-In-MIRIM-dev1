using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{

    public int nextScene;
    
    void Start()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(nextScene);
    }
    
}
