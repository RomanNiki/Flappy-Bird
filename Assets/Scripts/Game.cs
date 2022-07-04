using UI;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird.Bird _bird;
    [SerializeField] private PipeGenerator _generator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _endScreen.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _endScreen.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }
    
    private void OnRestartButtonClick()
    {
        _endScreen.Close();
        _generator.ResetPool();
        StartGame();
    } 
    
    private void StartGame()
    {
        _bird.ResetPlayer();
        Time.timeScale = 1;
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endScreen.Open();
    }
}