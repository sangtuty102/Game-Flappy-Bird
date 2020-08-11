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
        _MakeInstance();
        Time.timeScale = 0;
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
        bestScore.text = "" + FlappyBirdManager.instance._getBestScore();

        int aaaa = FlappyBirdManager.instance._getBestScore();
        if (_score > aaaa)
        {
            FlappyBirdManager.instance._setBestScore(_score);
        }
        bestScore.text = "" + FlappyBirdManager.instance._getBestScore();

    }

    [System.Obsolete]
    public void _onClickExit()
    {
        Application.LoadLevel("HomeMenu");
    }

    [System.Obsolete]
    public void _onClickReplay()
    {
        Application.LoadLevel("PlayScene");
    }

}
