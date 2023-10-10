using System.Net.Http;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Enemy;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySearch : MonoBehaviour
{
   private EnemyUser _resultEnemy;
   private const string _urlEnemy = "https://randomuser.me/api/ ";

   public async Task<EnemyUser> GetEnemy()
   {


      using (UnityWebRequest www = UnityWebRequest.Get(_urlEnemy))
      {
         await www.SendWebRequest();
         string result = www.downloadHandler.text;
         
         var getResult = JObject.Parse(result)["results"][0];
         var nameEnemy =getResult["id"]["name"];
         var urlPhotoEnemy = getResult["picture"]["medium"];
         
         var enemyData = new EnemyData();
         enemyData.EnemyPhoto = urlPhotoEnemy.Value<string>();
         enemyData.EnemyName = nameEnemy.Value<string>();
         return new EnemyUser(enemyData);
      }
   }

   public void Active(bool activeSearch) => gameObject.SetActive(activeSearch);

}