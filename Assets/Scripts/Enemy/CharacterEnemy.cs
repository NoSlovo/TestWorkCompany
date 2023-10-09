using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class CharacterEnemy : MonoBehaviour,IPointerDownHandler
{
   [SerializeField] private TextMeshProUGUI _enemyName;

   private int _health;
   private string _enemyUserName;

   private const int _minHealth = 50;
   private const int _maxHealth = 101;
   private const int _damageMinTakeValue = 5;
   private const int _damageMaxTakeValue = 11;
   

   public int Health => _health;
   public string Name => _enemyUserName;
   
   public event Action<int> ITookDamage;
   public event Action IDead;

   public void SetEnemyUserData(EnemyUser EnemyUser)
   {
      if (EnemyUser == null)
         return;

      _enemyUserName = EnemyUser.Name;
      
      _enemyName.text = _enemyUserName;
      
      _health = Random.Range(_minHealth, _maxHealth);
   }
   
   public void OnPointerDown(PointerEventData eventData)
   {
     var damage = Random.Range(_damageMinTakeValue, _damageMaxTakeValue);
      TakeDamage(damage);
      
      if (_health <= 0)
         IDead?.Invoke();  
      
   }

   private void TakeDamage(int damage)
   {
      if (damage <= 0)
         return;

      _health -= damage;
      ITookDamage?.Invoke(damage);
   }

}
