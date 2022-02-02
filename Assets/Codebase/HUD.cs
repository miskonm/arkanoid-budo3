using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    #region Variables

    public TextMeshProUGUI ScoreLabel;

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        ScoreLabel.text = $"Score: {GameManager.Instance.Score}";
    }

    #endregion
}
