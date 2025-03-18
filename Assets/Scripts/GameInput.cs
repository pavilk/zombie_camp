<<<<<<< HEAD
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInput;

    public static GameInput Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        playerInput = new PlayerInputActions();
        playerInput.Enable();
    }

    public Vector2 MovementVector => playerInput.Player.Move.ReadValue<Vector2>();
}
=======
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInput;

    public static GameInput Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        playerInput = new PlayerInputActions();
        playerInput.Enable();
    }

    public Vector2 MovementVector => playerInput.Player.Move.ReadValue<Vector2>();
}
>>>>>>> 6c95146 (main)
