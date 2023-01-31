using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{

    public string gameScene;
    
    public void startGame()
    {
        SceneManager.LoadScene(gameScene);
    }
}
