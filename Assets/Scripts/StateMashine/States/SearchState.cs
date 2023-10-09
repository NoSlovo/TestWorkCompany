using UnityEngine;
using UnityEngine.UI;

namespace StateMashine.States
{
    public class SearchState : MonoBehaviour,IStateGame
    {
        [SerializeField] private GameStateMachine stateMachine;
        [SerializeField] private SearchScreen _searchScreen;
        [SerializeField] private Button _buttonEnterBattle;

        private void OnEnable() => _buttonEnterBattle.onClick.AddListener(EnterButtle);

        public void EnterState()
        {
            _searchScreen.Active(true);
            _searchScreen.StartEnemySearch();
        }

        public void ExitState() => _searchScreen.Active(true);

        private void EnterButtle() => stateMachine.EnterState<BattleState>();

        private void OnDisable() => _buttonEnterBattle.onClick.RemoveListener(EnterButtle);
    }
}