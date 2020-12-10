using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public bool isGameOver;
    public bool isMainGame;

    void Update()
    {
        if (isMainGame)
        {
            SceneManager.LoadScene("Main");
        }

        if (isGameOver)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
