using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarView : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _speed;
    
    private Slider _slider;
    private Coroutine _currentCoroutine;
    
    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _playerHealth.HealthChange += OnHealthChange;
    }

    private void OnDisable()
    {
        _playerHealth.HealthChange -= OnHealthChange;
    }

    private void OnHealthChange()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(ChangeSliderValue());
    }

    private IEnumerator ChangeSliderValue()
    {
        while (_slider.value != _playerHealth.Health) 
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _playerHealth.Health, _speed * Time.deltaTime);
            yield return null;
        }     
    }
}