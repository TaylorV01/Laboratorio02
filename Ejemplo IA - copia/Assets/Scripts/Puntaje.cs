using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText; 
    public int pointsToCollect = 3; 

    void Start()
    {
      
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
        }
        UpdateScoreUI(); 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            score -= 1;
            Destroy(collision.gameObject); 
            UpdateScoreUI(); 
        }
        else if (collision.gameObject.tag == "Objective")
        {
            score += 1;
            Destroy(collision.gameObject); 
            UpdateScoreUI(); 

     
            if (score % pointsToCollect == 0)
            {
                PlayerPrefs.SetInt("Score", score); 
                PlayerPrefs.Save(); 
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
            }
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
