using UnityEngine;

public class MovementControl : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 100;

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * _movementSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * _movementSpeed * Time.deltaTime;

        transform.Translate(horizontal, vertical, 0);
    }
}
