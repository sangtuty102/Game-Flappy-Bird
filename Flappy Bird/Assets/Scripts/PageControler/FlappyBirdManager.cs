using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdManager : MonoBehaviour
{
    public static FlappyBirdManager instance;

    private const string BESTCORE = "BESTCORE";

    void Awake()
    {
        _makeInstance();
        _initialGame();
        PlayerPrefs.SetInt(BESTCORE, 10);

    }

    void _initialGame()
    {
        if (!PlayerPrefs.HasKey("INITIAL_GAME_FLAPPY_BIRD"))
        {
            PlayerPrefs.SetInt(BESTCORE, 10);
            PlayerPrefs.SetInt("INITIAL_GAME_FLAPPY_BIRD", 0);
        }
    }

    void _makeInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void _setBestScore(int score)
    {
        PlayerPrefs.SetInt(BESTCORE, score);
    }

    public int _getBestScore()
    {
        return PlayerPrefs.GetInt(BESTCORE);
    }
}
