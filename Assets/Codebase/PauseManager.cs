using UnityEngine;

public class PauseManager : MonoBehaviour
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


    #region Private methods

    private bool IsEscPressed()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }

    private void TogglePause()
    {
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0 : 1;
    }

    #endregion
}
