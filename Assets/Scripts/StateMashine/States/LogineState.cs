using System;
using Unity.VisualScripting;
using UnityEngine;

namespace StateMashine.States
{
    public class LogineState : MonoBehaviour,IStateGame
    {
        [SerializeField] private GameStateMahine _stateMahine;
        [SerializeField] private LogineScreen _logineScreen;
        [SerializeField] private User _user;

        private void OnEnable()
        {
            _logineScreen.UserLogine += EnterState;
        }

        public void EnterState()
        {
            if (_user.Name != "Player")
            {
                _stateMahine.EnterState<SearchState>();
                return;
            }
            _logineScreen.gameObject.SetActive(true);
        }

        public void ExitState()
        {
            _logineScreen.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _logineScreen.UserLogine -= EnterState;
        }
    }
}