using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DelayHelper : MonoBehaviour
{
    [SerializeField] [Range(0, 60)] private float _seconds = 1;
    [SerializeField] private UnityEvent _onAfterDelay;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_seconds);
        _onAfterDelay.Invoke();
    }

}