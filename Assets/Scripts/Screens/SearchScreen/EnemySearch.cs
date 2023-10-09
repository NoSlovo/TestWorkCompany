using System.Net.Http;
using System.Threading.Tasks;
using Enemy;
using Newtonsoft.Json.Linq;
using UnityEngine;
public class EnemySearch : MonoBehaviour
{
   private EnemyUser _resultEnemy;
   private const string _urlEnemy = "https://randomuser.me/api/ ";
   public EnemyUser ResultEnemy => _resultEnemy;

   public void GetEnemy()
   {
      _resultEnemy = null;
      using (var http = new HttpClient())
      {
         Task<string> result =  http.GetStringAsync(_urlEnemy);
         
         var nameEnemy = JObject.Parse(result.Result)["results"][0]["id"]["name"];
         var urlPhotoEnemy = JObject.Parse(result.Result)["results"][0]["picture"]["medium"];
      
         var enemyData = new EnemyData();
         enemyData.EnemyPhoto = urlPhotoEnemy.Value<string>();
         enemyData.EnemyName = nameEnemy.Value<string>();
         _resultEnemy = new EnemyUser(enemyData);
      }
   }
   
}