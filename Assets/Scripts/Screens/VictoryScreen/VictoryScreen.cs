using TMPro;
using UnityEngine;
using Random = System.Random;

namespace Screens.VictoryScreen
{
    public class VictoryScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameEnemy;
        [SerializeField] private TextMeshProUGUI _rewardCount;
        [SerializeField] private CharacterEnemy _enemy;
        [SerializeField] private User _user;
        
        public void SetRewardUser()
        {
            var coin = CoinGenerationReward();
            _rewardCount.text = $"{coin}";
            _user.AddCoin(coin);
        }
        
        public void Active(bool activeSearch) => gameObject.SetActive(activeSearch);

        private int CoinGenerationReward()
        {
            var random = new Random();
            var valueReaward =  random.Next(100, 1001);
            return valueReaward;
        }
    }
}