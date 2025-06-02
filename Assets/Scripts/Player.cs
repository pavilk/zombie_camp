using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float movingSpeed = 5f;
    [SerializeField] private DialogueManager dialogueManager;

    private Rigidbody2D body;
    private float minSpeed = 0.1f;
    private bool isRunning = false;
    private int direction = 0;

    private GameData gameData;

    private void Awake()
    {
        Instance = this;
        body = GetComponent<Rigidbody2D>();
        if (GameData.SpawnPosition != new Vector3(0, 0, 0))
            Instance.transform.position = GameData.SpawnPosition;
    }

    private void Start()
    {
        if (!GameData.introSeen && dialogueManager != null)
        {
            ShowIntroDialogue();
            GameData.introSeen = true;
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && DialogueManager.Instance.IsDialoguePlaying)
        {
            DialogueManager.Instance.DisplayNextLine();
        }

    }

    private void HandleMovement()
    {
        if (DialogueManager.Instance != null && DialogueManager.Instance.IsDialoguePlaying)
        {
            body.linearVelocity = Vector2.zero;
            isRunning = false;
            return;
        }

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


    private void ShowIntroDialogue()
    {
        var lines = new List<DialogueLine>
        {
            new DialogueLine { speakerName = "Вася", sentence = "Да куда все делись? Словно сквозь землю провалились." },
            new DialogueLine { speakerName = "Вася", sentence = "А стоп.. Вроде кто-то стоит на площади - пойду проверю." }
        };

        dialogueManager.StartDialogue(lines);
    }

    public int GetDirection() => direction;
    public bool IsRunning() => isRunning;
}
