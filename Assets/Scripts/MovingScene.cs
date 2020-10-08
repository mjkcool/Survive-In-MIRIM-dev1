using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingScene : MonoBehaviour
{
    public int NextSceneNumber;
    // Start is called before the first frame update
    public void move()
    {
        SceneManager.LoadScene(NextSceneNumber);
    }

}
