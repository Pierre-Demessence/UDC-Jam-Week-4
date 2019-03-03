using System;
using UnityEngine;

public class RestrictToViewPort : MonoBehaviour
{
    private Camera _camera;

    // The minimum and maximum values which the object can go
    private float
        _clampMinX,
        _clampMaxX,
        _clampMinY,
        _clampMaxY;
    [SerializeField] private float _clampX = 0.1f;
    [SerializeField] private float _clampY = 0.1f;
    private float _maxClampX;
    private float _maxClampY;

    // Start is called before the first frame update
    private void Start()
    {
        _camera = Camera.main;
        _maxClampX = 1 - _clampX;
        _maxClampY = 1 - _clampY;

        // Get the minimum and maximum position values according to the screen size represented by the main camera.
        _clampMinX = _camera.ScreenToWorldPoint(new Vector2(0 + _clampX, 0)).x;
        _clampMaxX = _camera.ScreenToWorldPoint(new Vector2(Screen.width - _maxClampX, 0)).x;
        _clampMinY = _camera.ScreenToWorldPoint(new Vector2(0, 0 + _clampY)).y;
        _clampMaxY = _camera.ScreenToWorldPoint(new Vector2(0, Screen.height + _maxClampY)).y;
    }

    private void LateUpdate()
    {
        if (transform.position.x < _clampMinX || transform.position.x > _clampMaxX || transform.position.y < _clampMinY || transform.position.y > _clampMaxY)
        {
            
            var pos = _camera.WorldToViewportPoint(transform.position);
            
            pos.x = Mathf.Clamp(pos.x, _clampX, _maxClampX);
            pos.y = Mathf.Clamp(pos.y, _clampY, _maxClampY);

            var viewportToWorldPoint = _camera.ViewportToWorldPoint(pos);
            
            transform.position = viewportToWorldPoint;
        }
    }
}