using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private UnityEvent _onHealthChanged;
    
    private int _minHealth = 0;
    private int _maxHealth = 100;
    private int _health;
    
    public int Health => _health;
    
    private void Start()
    {
        _health = _maxHealth;
    }

    public void Heal(int heal)
    {
        _health += heal;
        _health = Mathf.Clamp(_health, _minHealth, _maxHealth);
        
        _onHealthChanged?.Invoke();
    }

    public void DealDamage(int damage)
    {
        _health -= damage;
        _health = Mathf.Clamp(_health, _minHealth, _maxHealth);
        
        _onHealthChanged?.Invoke();
    }
}