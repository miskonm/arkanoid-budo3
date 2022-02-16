using UnityEngine;

public class PauseManager : SingletoneMonoBehaviour<PauseManager>
{
    #region Properites

    public bool IsPaused { get; private set; } = false;

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (IsEscPressed())
        {
            TogglePause();
        }
    }

    #endregion


    #region Public methods

    public void Pause()
    {
        IsPaused = true;
        ApplyTimeScale();
    }

    public void UnPause()
    {
        IsPaused = false;
        ApplyTimeScale();
    }

    #endregion


    #region Private methods

    private bool IsEscPressed()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }

    private void TogglePause()
    {
        IsPaused = !IsPaused;
        ApplyTimeScale();
    }

    private void ApplyTimeScale()
    {
        Time.timeScale = IsPaused ? 0 : 1;
    }

    #endregion
}