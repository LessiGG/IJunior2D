using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _heal;
    [SerializeField] private int _damage;
    
    private int _health = 100;
    private int _maxHealth = 100;

    public int GetHealth()
    {
        return _health;
    }

    public void Heal()
    {
        _health += _heal;
        
        if (_health > _maxHealth)
            _health = _maxHealth;
    }

    public void DealDamage()
    {
        _health -= _damage;

        if (_health < 0)
            _health = 0;
    }
}