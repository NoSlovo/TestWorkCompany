using StateMashine;
using StateMashine.States;
using UnityEngine;

public class GameStateMahine : MonoBehaviour
{
    private IStateGame _state;

    private void Start()
    {
        EnterState<LogineState>();
    }

    public void EnterState<TState>() where TState:IStateGame
    {
        _state?.ExitState();
        _state = GetComponent<TState>();
        _state.EnterState();
    }
}
