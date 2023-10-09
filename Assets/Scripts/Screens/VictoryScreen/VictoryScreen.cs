using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Screens.VictoryScreen
{
    public class VictoryScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameEnemy;
        [SerializeField] private TextMeshProUGUI _rewardCount;
        [SerializeField] private CharacterEnemy _enemy;
        [SerializeField] private User _user;
        [SerializeField] private Button _buttonContinue;

        public Button ButtonContinue => _buttonContinue;
        
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