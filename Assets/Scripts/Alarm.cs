using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _volumeIncreaseSpeed;
    
    private bool _isTurned;
    private float _minVolume = 0;
    private float _maxVolume = 1;
    
    private AudioSource _audioSource;
    private Coroutine _coroutine;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void TurnOn()
    {
        _isTurned = true;
        OnSwitch();
    }

    public void TurnOff()
    {
        _isTurned = false;
        OnSwitch();
    }

    private void OnSwitch()
    {
        if (_isTurned)
        {
            _coroutine = StartCoroutine(ChangeVolume(_maxVolume));
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(ChangeVolume(_minVolume));
        }
    }

    private IEnumerator ChangeVolume(float target)
    {
        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _volumeIncreaseSpeed * Time.deltaTime);
            yield return null;
        }
    }   
}