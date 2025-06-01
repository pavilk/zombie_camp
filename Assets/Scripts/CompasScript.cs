using UnityEngine;

public class CompassArrowController : MonoBehaviour
{
    [Header("Настройки")]
    public Transform player; 
    public Transform target; 
    public RectTransform arrow; 
    public bool smoothRotation = true;
    public float rotationSpeed = 8f;

    private Vector2 lastValidDirection;

    private void Update()
    {
        if (player == null || target == null || arrow == null)
            return;
        Vector2 direction = (target.position - player.position);

        if (direction == Vector2.zero)
            direction = lastValidDirection;
        else
            lastValidDirection = direction;

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        var targetRotation = Quaternion.Euler(0, 0, angle - 90f);

        if (smoothRotation)
        {
            arrow.rotation = Quaternion.Lerp(
                arrow.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
        else
        {
            arrow.rotation = targetRotation;
        }
    }
}
