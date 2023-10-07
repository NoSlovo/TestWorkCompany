using UnityEngine;
using UnityEngine.UI;

public class UploadingImage : MonoBehaviour
{
    private Image _enemyImage;

    private void Awake()
    {
        _enemyImage = GetComponent<Image>();
    }

    public void SetImage(Texture2D texture)
    {
        _enemyImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }
    
}
