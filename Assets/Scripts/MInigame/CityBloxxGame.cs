using UnityEngine;

public class CityBloxxGame : MonoBehaviour
{
    [Header("Game Settings")]
    public float moveSpeed = 2f;
    public float moveRange = 3f;
    public float dropGravity = 5f;
    public float verticalOffset = 0.6f;
    public int winHeight = 10;

    [Header("References")]
    public Transform spawnArea;
    public Transform initialPlatform;
    public GameObject[] ingredientPrefabs;
    public Camera mainCamera;

    private GameObject currentBlock;
    private bool isDropping = false;
    private float cameraStartY;
    private int currentLayer = 0;

    void Start()
    {
        if (!spawnArea || !initialPlatform || ingredientPrefabs.Length == 0)
        {
            Debug.LogError("Missing references.");
            return;
        }

        cameraStartY = mainCamera.transform.position.y;
        SpawnBlock();
    }

    void Update()
    {
        if (currentBlock == null || isDropping) return;

        float offset = Mathf.PingPong(Time.time * moveSpeed, moveRange * 2) - moveRange;
        Vector3 pos = spawnArea.position + Vector3.right * offset;
        currentBlock.transform.position = new Vector3(pos.x, currentBlock.transform.position.y, 0);

        if (Input.GetMouseButtonDown(0))
        {
            DropBlock();
        }
    }

    void DropBlock()
    {
        if (currentBlock == null) return;

        isDropping = true;
        var rb = currentBlock.AddComponent<Rigidbody2D>();
        rb.gravityScale = dropGravity;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        currentBlock.AddComponent<BoxCollider2D>();
        currentBlock.AddComponent<BlockLander>().Init(this);
    }

    public void OnBlockLanded(GameObject block)
    {
        isDropping = false;

        // Ставим блок точно по высоте
        currentLayer++;
        float y = initialPlatform.position.y + currentLayer * verticalOffset;
        block.transform.position = new Vector3(block.transform.position.x, y, 0);

        var rb = block.GetComponent<Rigidbody2D>();
        if (rb) Destroy(rb);

        block.tag = "Platform"; // Обязательно для следующей посадки

        MoveCameraUp();

        if (currentLayer >= winHeight)
        {
            Debug.Log("You win!");
            return;
        }

        SpawnBlock();
    }

    void SpawnBlock()
    {
        Vector3 spawnPos = spawnArea.position;
        spawnPos.y = initialPlatform.position.y + (currentLayer + 1) * verticalOffset;

        int index = Random.Range(0, ingredientPrefabs.Length);
        currentBlock = Instantiate(ingredientPrefabs[index], spawnPos, Quaternion.identity);
    }

    void MoveCameraUp()
    {
        Vector3 camPos = mainCamera.transform.position;
        float targetY = initialPlatform.position.y + (currentLayer + 2) * verticalOffset;

        if (targetY > camPos.y)
        {
            camPos.y = targetY;
            mainCamera.transform.position = camPos;
        }
    }
}
