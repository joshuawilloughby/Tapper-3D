using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LivesSystem : MonoBehaviour
{
    public SceneController scene;
    public ScoreSystem score;

    public int maxLives = 3;
    public int currentLives;

    public Image image1;
    public Image image2;
    public Image image3;

    void Start()
    {
        currentLives = maxLives;
        image1.enabled = true;
        image2.enabled = true;
        image3.enabled = true;
    }

    void Update()
    {
        if (currentLives == 3)
        {
            image1.enabled = true;
            image2.enabled = true;
            image3.enabled = true;
        }

        if (currentLives == 2)
        {
            image1.enabled = true;
            image2.enabled = true;
            image3.enabled = false;
        }

        if (currentLives == 1)
        {
            image1.enabled = true;
            image2.enabled = false;
            image3.enabled = false;
        }

        if (currentLives == 0)
        {
            image1.enabled = false;
            image2.enabled = false;
            image3.enabled = false;

            scene.isGameOver = true;
        }
    }
}
