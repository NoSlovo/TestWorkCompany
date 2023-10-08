using UnityEngine;
using UnityEngine.UI;

namespace StateMashine.States
{
    public class BattleState : MonoBehaviour,IStateGame
    {
        [SerializeField] private GameStateMahine _stateMahine;
        [SerializeField] private BattleScreen _battleScreen;
        [SerializeField] private CharacterEnemy _enemy;

        public void EnterState()
        {
            _battleScreen.gameObject.SetActive(true);
        }

        public void ExitState()
        {
            _battleScreen.gameObject.SetActive(true);
        }
    }
}