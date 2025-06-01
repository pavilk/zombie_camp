using UnityEngine;

public class CompassArrowController : MonoBehaviour
{
    [Header("���������")]
    public Transform player;       // ��������� ���������
    public Transform target;       // ���� (������, �� ������� ���������)
    public RectTransform arrow;    // UI-������� (RectTransform)
    public bool smoothRotation = true;
    public float rotationSpeed = 8f;

    private Vector2 lastValidDirection;

    private void Update()
    {
        if (player == null || target == null || arrow == null)
            return;

        // ����������� � ���� � 2D (XY)
        Vector2 direction = (target.position - player.position);

        if (direction == Vector2.zero)
            direction = lastValidDirection;
        else
            lastValidDirection = direction;

        // ���� ����� "�������" � ������������ � ����
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ������������ ������� (UI � ��� Z �������� �� ��������)
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
