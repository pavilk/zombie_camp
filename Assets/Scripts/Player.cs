<<<<<<< HEAD
using NUnit.Framework.Constraints;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 5f;

    public static Player PlayerOne { get; private set; }

    private Rigidbody2D body;

    private void Awake()
    {
        PlayerOne = this;
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var inputVector = GameInput.Instance.MovementVector.normalized;
        //var inputVector = new Vector2(1, 0);



        body.MovePosition(body.position + inputVector * (movingSpeed * Time.fixedDeltaTime));


        if (Mathf.Abs(inputVector.x) > 0 || Mathf.Abs(inputVector.y) > 0)
        {
            float angle = Mathf.Atan2(inputVector.y, inputVector.x) * Mathf.Rad2Deg;

            // ������������ ���������
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public Vector3 GetPlayerPosition => transform.position;

}
=======
using NUnit.Framework.Constraints;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 5f;

    public static Player PlayerOne { get; private set; }

    private Rigidbody2D body;

    private void Awake()
    {
        PlayerOne = this;
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var inputVector = GameInput.Instance.MovementVector.normalized;
        //var inputVector = new Vector2(1, 0);



        body.MovePosition(body.position + inputVector * (movingSpeed * Time.fixedDeltaTime));


        if (Mathf.Abs(inputVector.x) > 0 || Mathf.Abs(inputVector.y) > 0)
        {
            float angle = Mathf.Atan2(inputVector.y, inputVector.x) * Mathf.Rad2Deg;

            // ������������ ���������
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public Vector3 GetPlayerPosition => transform.position;

}
>>>>>>> 6c95146 (main)
