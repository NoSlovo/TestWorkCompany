using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SearchScreen : MonoBehaviour
{
    [SerializeField] private EnemySearch _searchEnemy;
    [SerializeField] private ScreenResult _screenResult;
    [SerializeField] private Button _buttonSearch;
    [SerializeField] private Button _BattleEntryButton;
    [SerializeField] private BattleScreen _battleScreen;
    
    private void OnEnable()
    {
        _buttonSearch.onClick.AddListener(StartEnemySearch);
        _BattleEntryButton.onClick.AddListener(EnterButtle);
    }

    public void StartEnemySearch() => StartCoroutine(Search());

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

    private void EnterButtle()
    {
        _battleScreen.EnterBattleScreen();
    }

    private void OnDisable()
    {
        _buttonSearch.onClick.RemoveListener(StartEnemySearch);
        _BattleEntryButton.onClick.RemoveListener(EnterButtle);
    }
}
