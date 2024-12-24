using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject menu, gameover, gameplay;
    public Text scoreText, highScoreText, bestScoreText;


    private void Awake()
    {
        Instance = this;
    }


    public void OpenMenu()
    {
        CloseAll();
        menu.SetActive(true);

    }
    public void OpenGamePlay()
    {
        CloseAll();
        gameplay.SetActive(true);
       
        GameManager.Instance.isGamePlay = true;

        GameManager.Instance.flappyBirdControl.Init();
        
        scoreText.text = "0";
    }

    public void OpenGameover()
    {
        CloseAll();
        gameover.SetActive(true);
        GameManager.Instance.ClearAllPipes();
        GameManager.Instance.flappyBirdControl.SetUp();
        int highScore = GameManager.Instance.flappyBirdControl.Score;
        highScoreText.text = highScore.ToString();
        int bestScore = PlayerPrefs.GetInt("BESTSCORE",0);
        if(bestScore < highScore)
        {
            bestScore = highScore;
            PlayerPrefs.SetInt("BESTSCORE",bestScore);
        }
        bestScoreText.text = bestScore.ToString();
    }
    public void OpenGameoverDelay(float seconds)
    {
        Invoke("OpenGameover", seconds);
    }
    public void CloseAll()
    {
        menu.SetActive(false);
        gameplay.SetActive(false);
        gameover.SetActive(false);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
