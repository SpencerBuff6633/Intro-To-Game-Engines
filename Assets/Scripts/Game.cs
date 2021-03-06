using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    public int Score { get; set; } = 0;
    public int HighScore { get; set; } = 0;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI HighScoreUI;
    public TextMeshProUGUI timerUI;
    public GameObject startScreen;
    public GameObject gameOverScreen;
    public AudioSource music;

    static Game instance = null;

    float timer = 15.0f;

    private void Awake()
    {
        instance = this;
    }


    public enum eState
    {
        Title,
        StartGame,
        Game,
        GameOver
    }

    public eState State { get; set; } = eState.Title;


    private void Update()
    {

        switch (State)
        {
            case eState.Title:
                startScreen.SetActive(true);
                gameOverScreen.SetActive(false);
                break;
            case eState.StartGame:
                timer = 15;
                Score = 0;
                music.Play();
                startScreen.SetActive(false);
                State = eState.Game;
                break;
            case eState.Game:
                timer -= Time.deltaTime;
                timerUI.text = string.Format("{0:D2}", (int)timer);
                if (timer <= 0)
                {
                    music.Stop();
                    State = eState.GameOver;
                }
                break;
            case eState.GameOver:
                gameOverScreen.SetActive(true);
                if(Score > HighScore)
                {
                    HighScore = Score;
                    HighScoreUI.text = string.Format("{0:D4}", HighScore);
                }
                break;
        }
    }
    public static Game Instance
    {
        get
        {
            return instance;
        }
    }

    public void AddPoints(int points)
    {
        Score += points;
        scoreUI.text = string.Format("{0:D4}", Score);
    }

    public void StartGame()
    {
        State = eState.StartGame;
    }

    public void PlayAgain()
    {
        State = eState.Title;
    }
}
