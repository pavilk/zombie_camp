using UnityEngine;

public class CompassArrowController : MonoBehaviour
{
    [Header("Настройки")]
    public Transform player;       // Трансформ персонажа
    public Transform target;       // Цель (объект, на который указываем)
    public RectTransform arrow;    // UI-стрелка (RectTransform)
    public bool smoothRotation = true;
    public float rotationSpeed = 8f;

    private Vector2 lastValidDirection;

    private void Update()
    {
        if (player == null || target == null || arrow == null)
            return;

        // Направление к цели в 2D (XY)
        Vector2 direction = (target.position - player.position);

        if (direction == Vector2.zero)
            direction = lastValidDirection;
        else
            lastValidDirection = direction;

        // Угол между "вверхом" и направлением к цели
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Поворачиваем стрелку (UI — ось Z отвечает за вращение)
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle - 90f);

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
