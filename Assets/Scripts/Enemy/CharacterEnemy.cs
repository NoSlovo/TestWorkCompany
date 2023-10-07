using UnityEngine;

public class CharacterEnemy : MonoBehaviour,IDamageProvaider
{
   private EnemyUser _enemyUser;

   private int _health;


   public void SetEnemyUser(EnemyUser EnemyUser)
   {
      _enemyUser = EnemyUser;
      _health = Random.Range(50, 101);
   }


   public void TakeDamage(int damage)
   {
      if (damage > 0)
         _health -= damage;
   }
}

public interface IDamageProvaider
{
   public void TakeDamage(int damage);
}
