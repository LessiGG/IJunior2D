using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Door : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent _entered;
    [SerializeField] private UnityEvent _exited;

    private bool _isEntered;

    private void EnterHouse()
    {
        _isEntered = true;
        _entered?.Invoke();
    }
    
    private void ExitHouse()
    {
        _isEntered = false;
        _exited?.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isEntered == false)
            EnterHouse();
        else
            ExitHouse();
    }
}