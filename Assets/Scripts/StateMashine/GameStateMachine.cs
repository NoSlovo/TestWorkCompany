using System;
using System.Collections.Generic;
using Screens.VictoryScreen;
using StateMashine;
using StateMashine.States;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private LogineScreen _logineScreen;
    [SerializeField] private SearchScreen _searchScreen;
    [SerializeField] private BattleScreen _battleScreen;
    [SerializeField] private VictoryScreen _victoryScreen;
    [SerializeField] private User _user;

    private Dictionary<Type, IStateGame> _gameState;

    private IStateGame _state;

    private void Awake()
    {
        _gameState =  new Dictionary<Type, IStateGame>()
        {
            [typeof(LogineState)] = new LogineState(this,_logineScreen,_user),
            [typeof(SearchState)] = new SearchState(this,_searchScreen),
            [typeof(BattleState)] = new BattleState(this,_battleScreen),
            [typeof(VictoryState)] = new VictoryState(this,_victoryScreen)
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
