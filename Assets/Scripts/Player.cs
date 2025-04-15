
using NUnit.Framework.Constraints;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float movingSpeed = 5f;
    private bool isRunning = false;
    private int direction = 0;
    private float minSpeed = 0.1f;
    private Rigidbody2D body;

    private void Awake()
    {
        Instance = this;
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        var inputVector = GameInput.Instance.MovementVector.normalized;
        body.MovePosition(body.position + inputVector * (movingSpeed * Time.fixedDeltaTime));


        
         if (inputVector.y > 0 )
            direction = 3;
         if (inputVector.y < 0)
            direction = 0;
        if (inputVector.x > 0)
        {
            direction = 1;
        }

        if (inputVector.x < 0)
            direction = 2;

        if (Mathf.Abs(inputVector.x) > minSpeed || Mathf.Abs(inputVector.y) > minSpeed)
            isRunning = true;
        else
            isRunning = false;

    }

    public int GetDirection() => direction;

    public bool IsRunning() => isRunning;
}
