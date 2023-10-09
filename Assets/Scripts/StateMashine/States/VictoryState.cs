using Screens.VictoryScreen;
using UnityEngine;
using UnityEngine.UI;

namespace StateMashine.States
{
    public class VictoryState : IStateGame
    {
         private GameStateMachine _gameStateMachine;
         private VictoryScreen _victoryScreen;

         public VictoryState(GameStateMachine stateMachine,VictoryScreen victoryScreen)
         {
             _gameStateMachine = stateMachine;
             _victoryScreen = victoryScreen;
         }

         public void EnterState()
        {
            _victoryScreen.ButtonContinue.onClick.AddListener(EnterSearchState);
             _victoryScreen.gameObject.SetActive(true);
             _victoryScreen.SetRewardUser();
        }

        public void ExitState()
        {
            _victoryScreen.Active(false);
            _victoryScreen.ButtonContinue.onClick.RemoveListener(EnterSearchState);
        }

        private void EnterSearchState()=> _gameStateMachine.EnterState<SearchState>();
    }
}