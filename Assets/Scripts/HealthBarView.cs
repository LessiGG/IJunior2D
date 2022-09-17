using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _speed;
    
    private Slider _slider;
    
    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void Update()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _playerHealth.GetHealth(), _speed * Time.deltaTime);
    }
}