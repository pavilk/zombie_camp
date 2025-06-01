using UnityEngine;

public class SandwichGame : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 2f;
    public float moveRange = 3f;
    public float dropGravity = 5f;
    public float verticalOffset = 0.2f; // Отступ между слоями

    [Header("References")]
    public GameObject[] ingredientPrefabs;
    public Transform spawnArea;
    public Transform breadBase; // Основание бутерброда

    private GameObject currentIngredient;
    private Vector3 startPosition;
    private bool isActive = true;
    private int currentLayer = 0; // Текущий слой бутерброда

    void Start()
    {
        if (spawnArea == null || breadBase == null)
        {
            Debug.LogError("Critical references not assigned!");
            return;
        }

        startPosition = spawnArea.position;
        SpawnNewIngredient();
    }

    void Update()
    {
        if (!isActive || currentIngredient == null) return;

        // Горизонтальное движение
        float pingPong = Mathf.PingPong(Time.time * moveSpeed, 2f) - 1f;
        currentIngredient.transform.position =
            startPosition + Vector3.right * pingPong * moveRange;

        if (Input.GetMouseButtonDown(0))
        {
            DropIngredient();
        }
    }

    void SpawnNewIngredient()
    {
        if (!isActive || ingredientPrefabs == null || ingredientPrefabs.Length == 0)
            return;

        int index = Random.Range(0, ingredientPrefabs.Length);
        currentIngredient = Instantiate(ingredientPrefabs[index], startPosition, Quaternion.identity);

        // Настройка физики
        Rigidbody2D rb = currentIngredient.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

        // Добавляем коллайдер, если отсутствует
        if (!currentIngredient.GetComponent<Collider2D>())
        {
            currentIngredient.AddComponent<BoxCollider2D>();
        }

        currentIngredient.AddComponent<IngredientController>().Initialize(this);
    }

    public void DropIngredient()
    {
        if (!isActive || currentIngredient == null) return;

        Rigidbody2D rb = currentIngredient.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = dropGravity;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        isActive = false;
    }

    public void HandleSuccessfulLanding()
    {
        // Позиционируем точно поверх бутерброда
        float yPosition = breadBase.position.y + (verticalOffset * currentLayer);
        currentIngredient.transform.position = new Vector3(
            currentIngredient.transform.position.x,
            yPosition,
            currentIngredient.transform.position.z
        );

        // Фиксируем
        Rigidbody2D rb = currentIngredient.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.linearVelocity = Vector2.zero;

        // Подготавливаем следующий слой
        currentLayer++;
        currentIngredient.transform.SetParent(breadBase);

        // Спавним следующий ингредиент
        isActive = true;
        SpawnNewIngredient();
    }
}