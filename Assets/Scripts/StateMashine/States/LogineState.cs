using UnityEngine;

namespace StateMashine.States
{
    public class LogineState : MonoBehaviour,IStateGame
    {
        [SerializeField] private GameStateMachine stateMachine;
        [SerializeField] private LogineScreen _logineScreen;
        [SerializeField] private User _user;

        private const string _defaultNameUser = "Player";

        private void OnEnable() => _logineScreen.ButtonEnter.onClick.AddListener(EnterState);

        public void EnterState()
        {
            if (_user.Name != _defaultNameUser)
            {
                stateMachine.EnterState<SearchState>();
                return;
            }
            _logineScreen.gameObject.SetActive(true);
        }

        public void ExitState() => _logineScreen.gameObject.SetActive(false);
        
        private void OnDisable() => _logineScreen.ButtonEnter.onClick.RemoveListener(EnterState);
        
    }
}