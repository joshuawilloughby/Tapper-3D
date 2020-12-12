using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public Text currentScore;
    public Text finalScore;
    public int score;
    public GameObject canvas;

    public void Start()
    {
        score = 0;
        currentScore.text = "Score: " + score;
    }
}
