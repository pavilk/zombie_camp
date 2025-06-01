using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float movingSpeed = 5f;
    [SerializeField] private DialogueManager dialogueManager;

    private bool isRunning = false;
    private int direction = 0;
    private float minSpeed = 0.1f;
    private Rigidbody2D body;

    private void Awake()
    {
        Instance = this;
        body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ShowIntroDialogue();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogueManager != null)
        {
            dialogueManager.DisplayNextLine();
        }
    }

    private void HandleMovement()
    {
        var inputVector = GameInput.Instance.MovementVector.normalized;
        body.MovePosition(body.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

        if (inputVector.y > 0)
            direction = 3;
        if (inputVector.y < 0)
            direction = 0;
        if (inputVector.x > 0)
            direction = 1;
        if (inputVector.x < 0)
            direction = 2;

        isRunning = Mathf.Abs(inputVector.x) > minSpeed || Mathf.Abs(inputVector.y) > minSpeed;
    }

    public int GetDirection() => direction;
    public bool IsRunning() => isRunning;

    private void ShowIntroDialogue()
    {
        if (dialogueManager == null) return;

        var lines = new List<DialogueLine>
        {
            new DialogueLine { speakerName = "???", sentence = "Где я?.. Что это за место?" },
            new DialogueLine { speakerName = "???", sentence = "Нужно найти кого-нибудь, кто объяснит, что происходит." }
        };

        dialogueManager.StartDialogue(lines);
    }
}
