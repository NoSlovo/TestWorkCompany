using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBar : MonoBehaviour
{
    [SerializeField] private CharacterEnemy _enemy;
    
    private Image _bar;

    private float _defaultValue = 1f;

    private void OnEnable()
    {
        _enemy.ITookDamage += CharacterTakeDamage;
        _bar.fillAmount = _defaultValue;
    }

    private void Awake()=> _bar = GetComponent<Image>();

    private void CharacterTakeDamage(int damage)
    {
        if (damage <= 0)
            return;
        
        _bar.fillAmount = (float) _enemy.Health / 100;
    }

    private void OnDisable()=> _enemy.ITookDamage -= CharacterTakeDamage;
    
}