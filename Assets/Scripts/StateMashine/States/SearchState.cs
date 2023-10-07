using Unity.VisualScripting;
using UnityEngine;

namespace StateMashine.States
{
    public class SearchState : MonoBehaviour,IStateGame
    {
        [SerializeField] private GameStateMahine _stateMahine;
        [SerializeField] private SearchScreen _searchScreen;
        public void EnterState()
        {
            _searchScreen.gameObject.SetActive(true);
            _searchScreen.StartEnemySearch();
        }

        public void ExitState()
        {
            throw new System.NotImplementedException();
        }
    }
}