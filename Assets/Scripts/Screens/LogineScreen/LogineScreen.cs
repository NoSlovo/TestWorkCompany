using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogineScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _userText;
    [SerializeField] private Button _buttonLogine;
    [SerializeField] private User _user;

    public event Action UserLogine;
    public Button ButtonEnter => _buttonLogine;
    
    private const int _standardValue = 1;

    private void OnEnable() => _buttonLogine.onClick.AddListener(SetTextValue);
    
    private void Start() => SwitchingButtonState();

    public void SwitchingButtonState()
    {
        if (_userText.text.Length > _standardValue)
        {
            _buttonLogine.gameObject.SetActive(true);
            return;
        }

        _buttonLogine.gameObject.SetActive(false);
    }

    private void SetTextValue()
    {
        _user.SetName(_userText.text);
        UserLogine?.Invoke();
    } 
        
    
    private void OnDisable() => _buttonLogine.onClick.AddListener(SetTextValue);
}