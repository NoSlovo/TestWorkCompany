using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class ScreenResult : MonoBehaviour
{
    [Header("Игрок")]
    [SerializeField] private User _user;
    [SerializeField] private TextMeshProUGUI _userName;
    [SerializeField] private TextMeshProUGUI _coins;
    
    [Header("Враг")]
    [SerializeField] private TextMeshProUGUI _enemyName;

    [SerializeField] private UploadingImage _image;

    public Image EnemyImage;

    public void SetEnemyUser(EnemyUser EnemyUser)
     {
         if (EnemyUser == null)
            return;
         
         _userName.text = _user.Name;
         _coins.text = $"{_user.Coin}";
         _enemyName.text = EnemyUser.Name;
         
         gameObject.SetActive(true);
       // StartCoroutine(GetImage(EnemyUser));
     }


    // private IEnumerator GetImage(EnemyUser enemyUser)
    // {
    //     WWW image = new (enemyUser.Photo);
    //     yield return image;
    //     
    //     Texture2D loadedTexture = new Texture2D(image.texture.width, image.texture.height);
    //     image.LoadImageIntoTexture(loadedTexture);
    //     _image.SetImage(loadedTexture);
    // }
}
