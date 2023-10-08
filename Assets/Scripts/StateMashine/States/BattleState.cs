using UnityEngine;
using UnityEngine.Serialization;

namespace StateMashine.States
{
    public class BattleState : MonoBehaviour,IStateGame
    {
        [SerializeField] private GameStateMachine stateMachine;
        [SerializeField] private BattleScreen _battleScreen;
        [SerializeField] private CharacterEnemy _enemy;

        private void OnEnable()=> _enemy.IDead += EnterVictoryState;

        public void EnterState() => _battleScreen.gameObject.SetActive(true);

        public void ExitState() => _battleScreen.gameObject.SetActive(false);

        private void EnterVictoryState() => stateMachine.EnterState<VictoryState>();

        private void OnDisable() => _enemy.IDead += EnterVictoryState;
    }
}