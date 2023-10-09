using StateMashine;
using StateMashine.States;
using UnityEngine;

[RequireComponent(typeof(LogineState))]
[RequireComponent(typeof(SearchState))]
[RequireComponent(typeof(BattleState))]
[RequireComponent(typeof(VictoryState))]
public class GameStateMachine : MonoBehaviour
{
    private IStateGame _state;

    private void Start() => EnterState<LogineState>();
    
    public void EnterState<TState>() where TState:IStateGame
    {
        _state?.ExitState();
        _state = GetComponent<TState>();
        _state.EnterState();
    }
}
