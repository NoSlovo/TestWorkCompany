using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SearchScreen : MonoBehaviour
{
    [SerializeField] private EnemySearch _searchEnemy;
    [SerializeField] private ScreenResult _screenResult;
    [SerializeField] private Button _buttonSearch;
    [SerializeField] private Button _BattleEntryButton;
    [SerializeField] private BattleScreen _battleScreen;
    [SerializeField] private Button _enterBattleButton;

    public Button EnterBattleButton => _enterBattleButton;

    private void OnEnable() => _buttonSearch.onClick.AddListener(StartEnemySearch);

    public void StartEnemySearch() => StartCoroutine(Search());

    private IEnumerator Search()
    {
        var WaitForSecondsRealtime = new WaitForSecondsRealtime(1f);
        
        _searchEnemy.Active(true);
        _screenResult.Active(false);
        _searchEnemy.BuildEnemy();
        
        yield return WaitForSecondsRealtime;
        EnterScreenResult();
    }

    private void EnterScreenResult()
    {
        _screenResult.SetEnemyUser(_searchEnemy.ResultEnemy);
        _searchEnemy.Active(false);
        _screenResult.Active(true);
    }
    
    public void Active(bool activeSearch) => gameObject.SetActive(activeSearch);

    private void OnDisable()=> _buttonSearch.onClick.RemoveListener(StartEnemySearch);
}
