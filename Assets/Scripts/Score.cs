using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    public TextMeshProUGUI endScoreText;
    public TextMeshProUGUI highScoreText;
    private float highScore;
    private static float scoreOnDestroy;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        if (!Events.isRespawnScore)
        {
            scoreOnDestroy = 0;
        }
        else
        {
            Events.isRespawnScore = false;
        }
        scoreText.text = scoreOnDestroy.ToString();
        endScoreText.text = "SCORE : " + scoreOnDestroy.ToString();
        highScoreText.text = "HIGH SCORE : " + PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Platforms.isDestroyed)
        {
            scoreOnDestroy++;
            if (scoreOnDestroy > PlayerPrefs.GetFloat("HighScore", 0))
            {
                PlayerPrefs.SetFloat("HighScore", scoreOnDestroy);
            }
            scoreText.text = scoreOnDestroy.ToString();
            endScoreText.text = "SCORE : " + scoreOnDestroy.ToString();
            highScoreText.text = "HIGH SCORE : " + PlayerPrefs.GetFloat("HighScore", 0).ToString();
        }
    }
}
