public class GameManager : SingletoneMonoBehaviour<GameManager>
{
    #region Properties

    public int Score { get; private set; }

    #endregion


    #region Public methods

    public void Reset()
    {
        Score = 0;
    }

    public void AddScore(int score)
    {
        Score += score;
    }

    #endregion
}