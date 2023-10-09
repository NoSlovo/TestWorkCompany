using UnityEngine;

namespace StateMashine.States
{
    public class LogineState : IStateGame
    {
         private GameStateMachine _stateMachine;
         private LogineScreen _logineScreen;
         private User _user;

         public LogineState(GameStateMachine stateMachine, LogineScreen logineScreen,User user)
         {
             _stateMachine = stateMachine;
             _logineScreen = logineScreen;
             _user = user;
         }

        private const string _defaultNameUser = "Player";

        private void OnEnable() => _logineScreen.ButtonEnter.onClick.AddListener(EnterState);

        public void EnterState()
        {
            if (_user.Name != _defaultNameUser)
            {
                _stateMachine.EnterState<SearchState>();
                return;
            }
            _logineScreen.Active(true);
        }

        public void ExitState() => _logineScreen.Active(false);
        
        private void OnDisable() => _logineScreen.ButtonEnter.onClick.RemoveListener(EnterState);
        
    }
}