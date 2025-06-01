using System.Threading;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField]
    static int dellimiter = 20;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        var keyPressed = KeyNameDetector.KeyName;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.SetRotation(body.rotation + Mathf.PI / dellimiter);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            body.SetRotation(body.rotation - Mathf.PI / dellimiter);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            body.MovePosition(body.position + Vector2.right / dellimiter);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.MovePosition(body.position + Vector2.left / 50);
        }

        KeyNameDetector.KeyName = null;
    }
}
