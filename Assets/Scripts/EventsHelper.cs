using UnityEngine;
using UnityEngine.Events;

public class EventsHelper : MonoBehaviour
{
    [SerializeField] private UnityEvent _onDestroy;
    [SerializeField] private UnityEvent _onDisable;
    [SerializeField] private UnityEvent _onEnable;

    private void OnEnable()
    {
        _onEnable?.Invoke();
    }

    private void OnDisable()
    {
        _onDisable?.Invoke();
    }

    private void OnDestroy()
    {
        _onDestroy?.Invoke();
    }
}