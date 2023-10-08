using System;
using UnityEngine;
using UnityEngine.UI;

namespace StateMashine.States
{
    public class SearchState : MonoBehaviour,IStateGame
    {
        [SerializeField] private GameStateMahine _stateMahine;
        [SerializeField] private SearchScreen _searchScreen;
        [SerializeField] private Button _buttonEnterBattle;

        private void OnEnable() => _buttonEnterBattle.onClick.AddListener(EnterButtle);

        public void EnterState()
        {
            _searchScreen.gameObject.SetActive(true);
            _searchScreen.StartEnemySearch();
        }

        public void ExitState()
        {
            _searchScreen.gameObject.SetActive(true);
        }

        private void EnterButtle()
        {
            _stateMahine.EnterState<BattleState>();
        }

        private void OnDisable() => _buttonEnterBattle.onClick.RemoveListener(EnterButtle);
        
    }
}