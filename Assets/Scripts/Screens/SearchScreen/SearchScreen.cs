using System;
using UnityEngine;
using UnityEngine.UI;

public class SearchScreen : MonoBehaviour
{
    [SerializeField] private EnemySearch _searchEnemy;
    [SerializeField] private ScreenResult _screenResult;
    [SerializeField] private Button _buttonSearch;
    
    private void OnEnable()
    {
        _buttonSearch.onClick.AddListener(StartSearch);
        _searchEnemy.EnemyFound += _screenResult.SetEnemyUser;
    }

    private void Start()
    {
        StartSearch();
    }

    private void StartSearch()
    {
        _screenResult.gameObject.SetActive(false);
        _searchEnemy.GetEnemy();
    }

    private void OnDisable()
    {
        _searchEnemy.EnemyFound -= _screenResult.SetEnemyUser;
    }
}
