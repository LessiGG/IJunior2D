using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _volumeIncreaseSpeed;
    
    private bool _isTurned;
    private float _minAlarmVolume = 0;
    private float _maxAlarmVolume = 1;
    
    private AudioSource _audioSource;
    private Coroutine _coroutine;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void TurnOnAlarm()
    {
        _isTurned = true;
        OnAlarmSwitch();
    }

    public void TurnOffAlarm()
    {
        _isTurned = false;
        OnAlarmSwitch();
    }

    private void OnAlarmSwitch()
    {
        if (_isTurned)
        {
            _coroutine = StartCoroutine(ChangeVolume(_maxAlarmVolume));
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(ChangeVolume(_minAlarmVolume));
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