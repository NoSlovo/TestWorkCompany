using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UploadingImage : MonoBehaviour
{
    private Image _enemyImage;

    private void Awake() => _enemyImage = GetComponent<Image>();
    

    public void SetImage(Texture2D texture)
    {
        _enemyImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f));
    }
    
}
