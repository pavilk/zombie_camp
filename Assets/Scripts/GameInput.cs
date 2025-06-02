using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInput;
    public static GameInput Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        playerInput = new PlayerInputActions();
        playerInput.Enable();
    }

    private void OnDestroy()
    {
        if (playerInput != null)
        {
            playerInput.Disable();
            playerInput.Dispose();
        }
    }

    public Vector2 MovementVector => playerInput.Player.Move.ReadValue<Vector2>();
}
