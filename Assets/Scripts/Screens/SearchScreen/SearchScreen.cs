using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class SearchScreen : MonoBehaviour
{
    [SerializeField] private EnemySearch _searchEnemy;
    [SerializeField] private ScreenResult _screenResult;
    [SerializeField] private Button _buttonSearch;
    
    private void OnEnable()
    {
        _buttonSearch.onClick.AddListener(StartEnemySearch);
    }

    private void Start()
    {
        StartEnemySearch();
    }

    private void StartEnemySearch() => StartCoroutine(Search());

    private IEnumerator Search()
    {
        var WaitForSecondsRealtime = new WaitForSecondsRealtime(1f);
        _searchEnemy.gameObject.SetActive(true);
        _screenResult.gameObject.SetActive(false);
        _searchEnemy.GetEnemy();
        yield return WaitForSecondsRealtime;
        EnterScreenResult();
    }

    private void EnterScreenResult()
    {
        _screenResult.SetEnemyUser(_searchEnemy.ResultEnemy);
        _searchEnemy.gameObject.SetActive(false);
        _screenResult.gameObject.SetActive(true);
    }
}
