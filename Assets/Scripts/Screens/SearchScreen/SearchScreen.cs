using System;
using UnityEngine;

public class SearchScreen : MonoBehaviour
{
    [SerializeField] private EnemySearch _searchEnemy;
    [SerializeField] private GameObject _screenResult;

    private void OnEnable() => StartSearchEnemy();
    

    private void FixedUpdate()
    {
        if (_searchEnemy.ResultEnemy != null)
        {
            _searchEnemy.gameObject.SetActive(false);
            _screenResult.gameObject.SetActive(true);
        }
        else
        {
            _searchEnemy.gameObject.SetActive(true);
            _screenResult.gameObject.SetActive(false);
        }
    }

    public void StartSearchEnemy()
    {
        _searchEnemy.GetEnemy();
        
    } 
        
    
}
