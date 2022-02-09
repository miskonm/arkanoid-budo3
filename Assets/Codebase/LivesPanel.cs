using System;
using System.Collections.Generic;
using UnityEngine;

public class LivesPanel : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject _liveCellPrefab;
    [SerializeField] private Transform _cellsParent;

    private readonly List<GameObject> _cells = new List<GameObject>();

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        InstantiateCells();
        UpdateCells();
        
        GameManager.Instance.OnLivesChanged += UpdateCells;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnLivesChanged -= UpdateCells;
    }

    #endregion


    #region Private methods

    private void InstantiateCells()
    {
        for (int i = 0; i < GameManager.Instance.MaxLives; i++)
        {
            GameObject cell = Instantiate(_liveCellPrefab, _cellsParent);
            _cells.Add(cell);
        }
    }

    private void UpdateCells()
    {
        for (int i = 0; i < _cells.Count; i++)
        {
            GameObject cell = _cells[i];
            bool isActive = GameManager.Instance.CurrentLives > i;
            cell.SetActive(isActive);
        }
    }

    #endregion
}