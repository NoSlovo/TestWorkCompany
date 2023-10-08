using Enemy;

public class EnemyUser
{
   private EnemyData _data;

   public string Name => _data.EnemyName;
   public string Photo => _data.EnemyPhoto;

   public EnemyUser(EnemyData EnemyData)
   {
      _data = EnemyData;
   }
}