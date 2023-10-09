namespace StateMashine.States
{
    public class SearchState : IStateGame
    {
        private GameStateMachine _stateMachine;
        private SearchScreen _searchScreen;

        public SearchState(GameStateMachine StateMachine,SearchScreen SearchScreen)
        {
            _stateMachine = StateMachine;
            _searchScreen = SearchScreen;
        }
        
        public void EnterState()
        {
            _searchScreen.EnterBattleButton.onClick.AddListener(EnterButtle);
            _searchScreen.Active(true);
            _searchScreen.StartEnemySearch();
        }

        public void ExitState()
        {
            _searchScreen.Active(true);
            _searchScreen.EnterBattleButton.onClick.RemoveListener(EnterButtle);
        }

        private void EnterButtle() => _stateMachine.EnterState<BattleState>();
    }
}