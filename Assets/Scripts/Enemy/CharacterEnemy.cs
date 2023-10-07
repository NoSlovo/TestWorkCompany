using System;
using Enemy;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class CharacterEnemy : MonoBehaviour,IPointerDownHandler
{
   [SerializeField] private TextMeshProUGUI _enemyName;

   private int _health;

   public int Health => _health;
   
   public event Action<int> ITookDamage;
   
   public void SetEnemyUser(EnemyUser EnemyUser)
   {
      _enemyName.text = EnemyUser.Name;
      _health = Random.Range(50, 101);
   }

   public void TakeDamage(int damage)
   {
      Debug.Log(damage);
      if (damage > 0)
      {
         _health -= damage;
         ITookDamage?.Invoke(damage);
      }
   }

   public void OnPointerDown(PointerEventData eventData)
   {
     var damage =  Random.Range(5, 11);
      TakeDamage(damage);
   }
}
