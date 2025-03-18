
using NUnit.Framework.Constraints;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 5f;

    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var inputVector = GameInput.Instance.MovementVector.normalized;

        body.MovePosition(body.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > 0 || Mathf.Abs(inputVector.y) > 0)
        {
            float angle = Mathf.Atan2(inputVector.y, inputVector.x) * Mathf.Rad2Deg;

            // Поворот игрока
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
