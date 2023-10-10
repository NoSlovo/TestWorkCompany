using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class SearchScreen : MonoBehaviour,IScreen
{
    [SerializeField] private EnemySearch _searchEnemy;
    [SerializeField] private ScreenResult _screenResult;
    [SerializeField] private Button _buttonSearch;
    [SerializeField] private Button _BattleEntryButton;
    [SerializeField] private BattleScreen _battleScreen;
    [SerializeField] private Button _enterBattleButton;

    public Button EnterBattleButton => _enterBattleButton;

    private void OnEnable() => _buttonSearch.onClick.AddListener(StartEnemySearch);

    public void StartEnemySearch() => Search();

    private async void Search()
    {
        _searchEnemy.Active(true);
        _screenResult.Active(false);
        
        var enemy = _searchEnemy.GetEnemy();
        var result = await enemy;
        
        EnterScreenResult(result);
    }

    private void EnterScreenResult(EnemyUser user)
    {
        _screenResult.SetEnemyUser(user);
        _searchEnemy.Active(false);
        _screenResult.Active(true);
    }
    
    public void Active(bool activeSearch) => gameObject.SetActive(activeSearch);

    private void OnDisable()=> _buttonSearch.onClick.RemoveListener(StartEnemySearch);
}
