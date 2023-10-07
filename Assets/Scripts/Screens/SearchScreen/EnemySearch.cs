using System;
using System.Net.Http;
using Enemy;
using Newtonsoft.Json.Linq;
using UnityEngine;
public class EnemySearch : MonoBehaviour
{
   private EnemyUser _resultEnemy;
   private const string _urlEnemy = "https://randomuser.me/api/ ";
   public EnemyUser ResultEnemy => _resultEnemy;

   public event Action<EnemyUser> EnemyFound; 

   public async void GetEnemy()
   {
      gameObject.SetActive(true);
      _resultEnemy = null;
        
      using (var http = new HttpClient())
      {
         var result = await http.GetStringAsync(_urlEnemy);
         
         var nameEnemy = JObject.Parse(result)["results"][0]["id"]["name"];
         var urlPhotoEnemy = JObject.Parse(result)["results"][0]["picture"]["medium"];

         var enemyData = new EnemyData();
         enemyData.EnemyPhoto = urlPhotoEnemy.Value<string>();
         enemyData.EnemyName = nameEnemy.Value<string>();
         
         _resultEnemy = new EnemyUser(enemyData);
         EnemyFound?.Invoke(_resultEnemy);
      }
      
      gameObject.SetActive(false);
   }
   
}