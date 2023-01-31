using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private int m = 5;
    private int s = 0;

    private Text textoReloj;

    private void Start()
    {
        textoReloj = GetComponent<Text>();
        mostrarReloj(m, s);
        Invoke("updateTimer", 1f);
    }
    private void updateTimer()
    {
        s--;
        if (s < 0)
        {
            if (m == 0)
            {
                endGame();
            }
            else
            {
                m--;
                s = 59;
            }
        }

        mostrarReloj(m, s);
        Invoke("updateTimer", 1f);
    }

    void mostrarReloj(int m, int s)
    {
        if (s < 10)
        {
            textoReloj.text = m.ToString() + ":0" + s.ToString();
        }
        else
        {
            textoReloj.text = m.ToString() + ":" + s.ToString();
        }
        
    }

    void endGame()
    {
        SceneManager.LoadScene("GameOver");
    }
}
