using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public Text currentScore;
    public int score;

    public void Start()
    {
        score = 0;
        currentScore.text = "Score: " + score;
    }
}
