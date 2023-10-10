using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class ScreenResult : MonoBehaviour
{
    [SerializeField] private CharacterEnemy _enemy;
    
    [Header("Игрок")]
    [SerializeField] private User _user;
    [SerializeField] private TextMeshProUGUI _userName;
    [SerializeField] private TextMeshProUGUI _coins;
    
    [Header("Враг")]
    [SerializeField] private TextMeshProUGUI _enemyName;

    [SerializeField] private UploadingImage _image;

    private EnemyUser _enemyUser;

    public EnemyUser EnemyUser => _enemyUser;

    public void SetEnemyUser(EnemyUser Enemy)
     {
         if (Enemy == null)
            return;
         
         _enemyUser = Enemy;
         
         _userName.text = _user.Name;
         _coins.text = $"{_user.Coin}";
         _enemyName.text = _enemyUser.Name;
         _enemy.SetEnemyUserData(_enemyUser);
         gameObject.SetActive(true);
         GetImage(Enemy.Photo);
     }

    private async void GetImage(string enemyURLPhoto)
    {
        using (var www = UnityWebRequestTexture.GetTexture(enemyURLPhoto))
        {
            await www.SendWebRequest();
            
            var image = DownloadHandlerTexture.GetContent(www);
            Texture2D loadedTexture = image;
            _image.SetImage(loadedTexture);
        }
    }
    
    public void Active(bool activeSearch) => gameObject.SetActive(activeSearch);
}
