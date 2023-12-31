using UnityEngine;

public class BattleScreen : MonoBehaviour
{
    [SerializeField] private CharacterEnemy _enemy;

    public CharacterEnemy CharacterEnemy => _enemy;
    
    public void Active(bool activeSearch) => gameObject.SetActive(activeSearch);
}
