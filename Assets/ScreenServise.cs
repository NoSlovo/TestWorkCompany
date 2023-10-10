using DefaultNamespace;
using Screens.VictoryScreen;
using UnityEngine;

public class ScreenServise : MonoBehaviour
{
   [SerializeField] private LogineScreen _logineScreen;
   [SerializeField] private SearchScreen _searchScreen;
   [SerializeField] private BattleScreen _battleScreen;
   [SerializeField] private VictoryScreen _victoryScreen;

   private static ServiceLocator _serviceLocator;

   public ServiceLocator ServiceLocator => _serviceLocator;
   
   private void Awake()
   {
      ServiceLocator.Initialize();
      _serviceLocator = ServiceLocator.Current;
      
      ServiceLocator.Register(_logineScreen);
      ServiceLocator.Register(_searchScreen);
      ServiceLocator.Register(_battleScreen);
      ServiceLocator.Register(_victoryScreen);
      
   }
}
