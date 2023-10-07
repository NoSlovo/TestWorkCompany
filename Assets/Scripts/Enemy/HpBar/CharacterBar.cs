using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBar : MonoBehaviour
{
    [SerializeField] private CharacterEnemy _enemy;
    
    private Slider _slider;

    private int _maxHeal;

    private void OnEnable()
    {
        _enemy.ITookDamage += CharacterTakeDamage;
    }

    private void Awake()=> _slider = GetComponent<Slider>();

    public void SetCharacterHeal(int HealCharacter)
    {
        if (HealCharacter > 0)
            _maxHeal = HealCharacter;
    }

    private void CharacterTakeDamage(int damage)
    {
        if (damage <= 0)
            return;
        
        _slider.value = (float) _enemy.Health / 100;
    }

    private void OnDisable()=> _enemy.ITookDamage -= CharacterTakeDamage;
    
}