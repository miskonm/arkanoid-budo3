using UnityEngine;

public class GameManager : SingletoneMonoBehaviour<GameManager>
{
    #region Variables

    private bool _isGameOver;

    #endregion


    #region Properties

    public int Score { get; private set; }

    #endregion


    #region Unity lifecycle

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

    public void Reset()
    {
        Score = 0;
        _isGameOver = false;
    }

    public void AddScore(int score)
    {
        Score += score;
    }
    
    public void AddScore(Block block)
    {
        Score += block.Score;
    }

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