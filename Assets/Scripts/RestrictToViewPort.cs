using UnityEngine;

public class RestrictToViewPort : MonoBehaviour
{
    [SerializeField] private float _clampX = 0.1f;
    [SerializeField] private float _clampY = 0.1f;
    private float _maxClampX;
    private float _maxClampY;

    // The minimum and maximum values which the object can go
    private float
        _clampMinX,
        _clampMaxX,
        _clampMinY,
        _clampMaxY;

    // Start is called before the first frame update
    private void Start()
    {
        _maxClampX = 1 - _clampX;
        _maxClampY = 1 - _clampY;

        // Get the minimum and maximum position values according to the screen size represented by the main camera.
        _clampMinX = Camera.main.ScreenToWorldPoint(new Vector2(0 + _clampX, 0)).x;
        _clampMaxX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - _maxClampX, 0)).x;
        _clampMinY = Camera.main.ScreenToWorldPoint(new Vector2(0, 0 + _clampY)).y;
        _clampMaxY = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height + _maxClampY)).y;
    }

    private void LateUpdate()
    {
        if (transform.position.x < _clampMinX || transform.position.x > _clampMaxX || transform.position.y < _clampMinY || transform.position.y > _clampMaxY)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            if (transform.position.x < _clampMinX || transform.position.x > _clampMaxX)
            {
                pos.x = Mathf.Clamp(pos.x, _clampX, _maxClampX);
            }
            if (transform.position.y < _clampMinY || transform.position.y > _clampMaxY)
            {
                pos.y = Mathf.Clamp(pos.y, _clampY, _maxClampY);
            }
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
    }

}
