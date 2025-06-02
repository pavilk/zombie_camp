using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _chasingDistance = 4f;
    [SerializeField] private float _chasingSpeedMultiplier = 2f;

    private NavMeshAgent _navMeshAgent;
    private SpriteRenderer spriteRenderer;
    private Transform _playerTransform;
    private float _chasingSpeed;
    private float _originalSpeed;
    public static Animator Animator;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;

        _originalSpeed = _navMeshAgent.speed;
        _chasingSpeed = _originalSpeed * _chasingSpeedMultiplier;
    }

    private void Start()
    {
        _playerTransform = Player.Instance?.transform;

        if (_playerTransform == null)
        {
            Debug.LogError("EnemyAI: Player.Instance �� ������! �������, ��� ������ Player ���� � ����� � ���������������� ������ �����.");
        }
    }

    private void Update()
    {
        // �������� ��������� �������
        if (DialogueManager.Instance != null && DialogueManager.Instance.IsDialoguePlaying)
        {
            if (_navMeshAgent.hasPath)
                _navMeshAgent.ResetPath();

            return;
        }

        // �������� �� �������� ��������, �� ����� ������� �������� ������ ���� ���������
        if (Animator != null && Animator.GetCurrentAnimatorStateInfo(0).IsTag("NoMove"))
        {
            if (_navMeshAgent.hasPath)
                _navMeshAgent.ResetPath();
            return;
        }

        // --- Flip sprite �� ��� X ---
        if (_playerTransform != null)
        {
            float direction = _playerTransform.position.x - transform.position.x;
            Vector3 scale = spriteRenderer.transform.localScale;

            if (direction < 0)
                scale.x = -Mathf.Abs(scale.x);  // ����� ����� � ����
            else
                scale.x = Mathf.Abs(scale.x);   // ����� ������ � ���������� �������

            spriteRenderer.transform.localScale = scale;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);

        if (distanceToPlayer <= _chasingDistance && PushLever.PushedAlready)
        {
            if (_navMeshAgent.isOnNavMesh && _navMeshAgent.enabled)
            {
                _navMeshAgent.speed = _chasingSpeed;
                _navMeshAgent.SetDestination(_playerTransform.position);
            }
        }
        else
        {
            if (_navMeshAgent.hasPath)
            {
                _navMeshAgent.ResetPath();
                _navMeshAgent.speed = _originalSpeed;
            }
        }
    }


}
