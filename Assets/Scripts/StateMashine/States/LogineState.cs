using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace StateMashine.States
{
    public class LogineState : MonoBehaviour,IStateGame
    {
        [SerializeField] private GameStateMachine stateMachine;
        [SerializeField] private LogineScreen _logineScreen;
        [SerializeField] private User _user;

        private void OnEnable()
        {
            _logineScreen.ButtonEnter.onClick.AddListener(EnterState);
        }

        public void EnterState()
        {
            if (_user.Name != "Player")
            {
                stateMachine.EnterState<SearchState>();
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
            _logineScreen.ButtonEnter.onClick.RemoveListener(EnterState);
        }
    }
}