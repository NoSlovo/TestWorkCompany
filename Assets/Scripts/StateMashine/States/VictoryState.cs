using Screens.VictoryScreen;
using UnityEngine;
using UnityEngine.UI;

namespace StateMashine.States
{
    public class VictoryState : MonoBehaviour,IStateGame
    {
        [SerializeField] private GameStateMachine _gameStateMachine;
        [SerializeField] private VictoryScreen _victoryScreen;
        [SerializeField] private Button _buttonContinue;

        private void OnEnable()=> _buttonContinue.onClick.AddListener(EnterSearchState);

        public void EnterState()
        {
             _victoryScreen.gameObject.SetActive(true);
             _victoryScreen.SetRewardUser();
        }

        public void ExitState() => _victoryScreen.gameObject.SetActive(false);
        
        private void EnterSearchState()=> _gameStateMachine.EnterState<SearchState>();

        private void OnDisable()=> _buttonContinue.onClick.RemoveListener(EnterSearchState);
    }
}