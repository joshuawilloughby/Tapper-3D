using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public bool isGameOver;
    public bool isMainGame;

    public bool isAlreadyDisplayingGameOver;
    public bool isAlreadyDisplayingMainGame;

    public ScoreSystem score;

    public GameObject scoreSystem;

    public void Awake()
    {
        isAlreadyDisplayingGameOver = false;
        isAlreadyDisplayingMainGame = false;

        score.canvas.transform.Find("Score System").gameObject.SetActive(true);
    }

    void Update()
    {
        if (isMainGame && !isAlreadyDisplayingMainGame)
        {
            isAlreadyDisplayingMainGame = true;

            SceneManager.LoadScene("Main");
            score.score = 0;
            score.currentScore.text = "Score: " + score.score;

            score.canvas.transform.Find("Score System").gameObject.SetActive(true);
            score.canvas.transform.Find("Fixed Joystick").gameObject.SetActive(true);
            score.canvas.transform.Find("Serve").gameObject.SetActive(true);
            score.canvas.transform.Find("Pour").gameObject.SetActive(true);
            score.canvas.transform.Find("Lives").gameObject.SetActive(true);
        }

        if (isGameOver && !isAlreadyDisplayingGameOver)
        {
            PlayerPrefs.SetInt("Final Score", score.score);

            isAlreadyDisplayingGameOver = true;

            SceneManager.LoadScene("Game Over");

            score.canvas.transform.Find("Score System").gameObject.SetActive(false);
            score.canvas.transform.Find("Fixed Joystick").gameObject.SetActive(false);
            score.canvas.transform.Find("Serve").gameObject.SetActive(false);
            score.canvas.transform.Find("Pour").gameObject.SetActive(false);
            score.canvas.transform.Find("Lives").gameObject.SetActive(false);
        }
    }
}
