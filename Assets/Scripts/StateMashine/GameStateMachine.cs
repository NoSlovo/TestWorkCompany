using System;
using System.Collections.Generic;
using Screens.VictoryScreen;
using StateMashine;
using StateMashine.States;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private User _user;
    [SerializeField] private ScreenServise _screenServise;
    
    private Dictionary<Type, IStateGame> _gameState;

    private IStateGame _state;

    private void Awake()
    {

        _gameState = new Dictionary<Type, IStateGame>()
        {
            [typeof(LogineState)] = new LogineState(this,_screenServise.ServiceLocator.Get<LogineScreen>(),_user),
            [typeof(SearchState)] = new SearchState(this,_screenServise.ServiceLocator.Get<SearchScreen>()),
            [typeof(BattleState)] = new BattleState(this,_screenServise.ServiceLocator.Get<BattleScreen>()),
            [typeof(VictoryState)] = new VictoryState(this,_screenServise.ServiceLocator.Get<VictoryScreen>())
        };
    }

    private void Start() => EnterState<LogineState>();
    
    public void EnterState<TState>() where TState:IStateGame
    {
        _state?.ExitState();
        _state = _gameState[typeof(TState)]; 
        _state.EnterState();
    }
}
