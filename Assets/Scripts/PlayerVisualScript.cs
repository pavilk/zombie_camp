using UnityEngine;

public class PlayerVisualScript : MonoBehaviour
{
    private Animator animator;
    private const string IS_WALKING = "IsWalking";
    private const string WALKING_DIRECTION = "WalkingDirection";


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, Player.Instance.IsRunning());
        animator.SetInteger(WALKING_DIRECTION, Player.Instance.GetDirection());
    }
}
