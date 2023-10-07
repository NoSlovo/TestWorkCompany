using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class ScreenResult : MonoBehaviour
{
    [SerializeField] private Image _enemyPhoto;
    [SerializeField] private User _user;
    [SerializeField] private TextMeshProUGUI _userName;
    
     private EnemyUser _enemyUser;


     public void SetEnemyUser(EnemyUser EnemyUser)
     {
         if (EnemyUser == null)
            return;

         _enemyUser = EnemyUser;
     }
     
}
