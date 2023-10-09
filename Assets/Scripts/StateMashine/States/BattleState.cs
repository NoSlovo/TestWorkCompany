using UnityEngine;

namespace StateMashine.States
{
    public class BattleState : IStateGame
    {
         private GameStateMachine _stateMachine;
         private BattleScreen _battleScreen;

         public BattleState(GameStateMachine StateMachine,BattleScreen battleScreen)
         {
             _stateMachine = StateMachine;
             _battleScreen = battleScreen;

         }

         public void EnterState()
         {
             _battleScreen.CharacterEnemy.IDead += EnterVictoryState;
             _battleScreen.Active(true);
         }

         public void ExitState()
         {
             _battleScreen.Active(false);
             _battleScreen.CharacterEnemy.IDead -= EnterVictoryState;
         }

         private void EnterVictoryState() => _stateMachine.EnterState<VictoryState>();
    }
}