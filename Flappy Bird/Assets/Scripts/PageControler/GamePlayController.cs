using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{

    public static GamePlayController instance;

    [SerializeField]
    private Button buttonBegin;
    [SerializeField]
    private GameObject birdObject;
    [SerializeField]
    private Text currentScore, endScore, bestScore;

    public GameObject gameOverPanel;

    void Awake()
    {
        Time.timeScale = 0;
        _MakeInstance();
        birdObject.SetActive(false);
        gameOverPanel.SetActive(false);


    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void _ButtonBegin()
    {
        Time.timeScale = 1;
        buttonBegin.gameObject.SetActive(false);
        birdObject.SetActive(true);
    }

    public void _setScore(int score)
    {
        currentScore.text = "" + score;
    }

    public void _showPanelGameOver(int _score)
    {
        gameOverPanel.SetActive(true);
        endScore.text = _score.ToString();
      
       //bestScore.text = "" + FlappyBirdManager.instance._getBestCores();
        if (_score > FlappyBirdManager.instance._getBestScore())
        {
            FlappyBirdManager.instance._setBestScore(_score);
        }
        
    }

}
