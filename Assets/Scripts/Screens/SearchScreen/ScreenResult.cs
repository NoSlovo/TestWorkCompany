using System.Collections;
using TMPro;
using UnityEngine;

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
         StartCoroutine(GetImage(Enemy));
     }

    private IEnumerator GetImage(EnemyUser enemyUser)
    {
        using (WWW www = new WWW(enemyUser.Photo))
        {
            var image = new WWW(enemyUser.Photo);
            yield return image;
            Texture2D loadedTexture = new Texture2D(image.texture.width, image.texture.height);
            image.LoadImageIntoTexture(loadedTexture);
            _image.SetImage(loadedTexture);
        }
    }
    
    public void Active(bool activeSearch) => gameObject.SetActive(activeSearch);
}
