using System;
using UnityEngine;

public class GameManager : SingletoneMonoBehaviour<GameManager>
{
    #region Variables

    [Header("Lives Settings")]
    [SerializeField] private int _maxLives = 5;
    [SerializeField] private int _startLives = 3;

    [Header("Autoplay")]
    [SerializeField] private bool _needAutoplay;

    private int _currentLives;
    private bool _isGameOver;

    #endregion


    #region Events

    public event Action OnLivesChanged;

    #endregion


    #region Properties

    public int Score { get; private set; }

    public int CurrentLives
    {
        get => _currentLives; 
        set
        {
            _currentLives = value;

            if (_currentLives < 0)
                _currentLives = 0;

            if (_currentLives > _maxLives)
                _currentLives = _maxLives;
            
            OnLivesChanged?.Invoke();
        }
    }

    public int MaxLives => _maxLives;

    public bool NeedAutoplay => _needAutoplay;

    #endregion


    #region Unity lifecycle

    protected override void Awake()
    {
        base.Awake();

        CurrentLives = _startLives;
    }

    private void OnEnable()
    {
        LevelManager.Instance.OnGameOver += GameOver;
        Block.OnDestroyed += AddScore;
    }

    private void OnDisable()
    {
        LevelManager.Instance.OnGameOver -= GameOver;
        Block.OnDestroyed -= AddScore;
    }

    #endregion


    #region Public methods

    public void Reload()
    {
        Score = 0;
        _isGameOver = false;
        CurrentLives = _startLives;
    }

    public void AddScore(int score)
    {
        Score += score;
    }

    public void AddScore(Block block)
    {
        Score += block.Score;
    }

    // public void RemoveLive()
    // {
    //     if (CurrentLives <= 0)
    //     {
    //         return;
    //     }
    //
    //     CurrentLives--;
    //     OnLivesChanged?.Invoke();
    //
    //     if (CurrentLives <= 0)
    //     {
    //         // Game Over
    //         // Show lose view
    //     }
    // }
    //
    // public void AddLive()
    // {
    //     if (CurrentLives >= _maxLives)
    //     {
    //         return;
    //     }
    //
    //     CurrentLives++;
    //     OnLivesChanged?.Invoke();
    // }

    #endregion


    #region Private methods

    private void GameOver()
    {
        if (_isGameOver)
        {
            return;
        }

        _isGameOver = true;

        // Show game over view
        Debug.Log($"Game Over!");
    }

    #endregion
}