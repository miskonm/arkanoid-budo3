using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject _innerGO;
    [SerializeField] private TextMeshProUGUI _dynamicScoreLabel;
    [SerializeField] private Button _nextButton;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        _nextButton.onClick.AddListener(NextButtonClick);
    }

    private void Start()
    {
        SetVisible(false);
        LevelManager.Instance.OnLevelCleared += LevelCleared;
    }

    private void OnDestroy()
    {
        LevelManager.Instance.OnLevelCleared -= LevelCleared;
    }

    #endregion


    #region Private methods

    private void SetVisible(bool isActive)
    {
        _innerGO.SetActive(isActive);
    }

    private void LevelCleared()
    {
        Invoke(nameof(ShowScreen), 0.001f);
    }

    private void ShowScreen()
    {
        SetVisible(true);
        _dynamicScoreLabel.text = GameManager.Instance.Score.ToString();
    }

    private void NextButtonClick()
    {
        SceneLoader.LoadNextScene();
        PauseManager.Instance.UnPause();
    }

    #endregion
}