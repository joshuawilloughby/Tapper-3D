using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public int finalScore;
    public Text score;

    public void Start()
    {
        finalScore = PlayerPrefs.GetInt("Final Score");
        Debug.Log(finalScore);

        score.text = "Your final score: " + finalScore;
    }
}
