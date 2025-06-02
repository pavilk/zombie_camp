using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CityBloxxController : MonoBehaviour
{
    public GameObject blockPrefab;
    public Transform spawnPoint;
    public Transform towerBase;
    public float dropSpeed = 10f;
    public Camera mainCamera;

    public float spawnPointOffsetFromCameraY = 5f;
    public float cameraOffsetFromTopBlock = 3f;

    [Header("Randomization Settings")]
    public float minSpawnX = -2f;
    public float maxSpawnX = 2f;

    public float minMoveSpeed = 1.0f;
    public float maxMoveSpeed = 6.0f;

    public int floatingBlockOrderOffset = 100;

    private GameObject currentBlock;
    private float currentMoveSpeed;
    private bool movingRight = true;
    private int score = 0;
    private bool isDropping = false;
    private bool isGameOver = false;
    private bool hasWon = false;

    private GameObject lastLandedBlock = null;
    private bool isFirstBlock = true;

    void Start()
    {
        if (blockPrefab == null)
        {
            Debug.LogError("Ошибка: blockPrefab не назначен! Пожалуйста, назначьте префаб блока в инспекторе.");
            enabled = false;
            return;
        }

        BoxCollider2D towerBaseCollider = towerBase.GetComponent<BoxCollider2D>();
        if (towerBaseCollider == null)
        {
            Debug.LogError("Ошибка: У TowerBase отсутствует BoxCollider2D! Он необходим для взаимодействия с блоками.");
            enabled = false;
            return;
        }

        Time.timeScale = 1f;

        Vector3 initialCamPos = mainCamera.transform.position;
        initialCamPos.y = towerBaseCollider.bounds.max.y + cameraOffsetFromTopBlock;
        mainCamera.transform.position = initialCamPos;

        lastLandedBlock = towerBase.gameObject;
        isFirstBlock = true;

        SpawnBlock();
        UpdateScoreDisplay();
    }

    void Update()
    {
        if (isGameOver || hasWon) return;

        Vector3 currentCameraPos = mainCamera.transform.position;
        Vector3 newSpawnPointPos = spawnPoint.position;
        newSpawnPointPos.y = currentCameraPos.y + spawnPointOffsetFromCameraY;
        spawnPoint.position = newSpawnPointPos;

        if (currentBlock == null || isDropping) return;

        MoveBlock(currentMoveSpeed);
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            DropBlock();
        }
    }

    void MoveBlock(float speed)
    {
        float moveDirection = movingRight ? 1 : -1;
        currentBlock.transform.position += Vector3.right * speed * moveDirection * Time.deltaTime;

        if (Mathf.Abs(currentBlock.transform.position.x) > (maxSpawnX + 1f))
        {
            movingRight = !movingRight;
        }
    }

    void DropBlock()
    {
        isDropping = true;
        Rigidbody2D rb = currentBlock.AddComponent<Rigidbody2D>();
        rb.gravityScale = dropSpeed;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        BlockTrigger trigger = currentBlock.AddComponent<BlockTrigger>();
        trigger.controller = this;
    }

    public void OnBlockLanded(GameObject block)
    {
        if (isGameOver || hasWon) return;

        if (block != currentBlock) return;

        isDropping = false;

        BoxCollider2D currentBlockCollider = block.GetComponent<BoxCollider2D>();
        BoxCollider2D lastLandedBlockCollider = lastLandedBlock.GetComponent<BoxCollider2D>();

        if (currentBlockCollider == null)
        {
            Debug.LogError("Ошибка: У только что приземлившегося блока отсутствует BoxCollider2D! Проверьте префаб.");
            GameOver();
            return;
        }
        if (lastLandedBlockCollider == null)
        {
            Debug.LogError("Ошибка: У предыдущего блока или towerBase отсутствует BoxCollider2D! Проверьте GameObject 'towerBase' и префаб блока.");
            GameOver();
            return;
        }

        if (!isFirstBlock)
        {
            float currentBlockMinX = currentBlockCollider.bounds.min.x;
            float currentBlockMaxX = currentBlockCollider.bounds.max.x;

            float lastBlockMinX = lastLandedBlockCollider.bounds.min.x;
            float lastBlockMaxX = lastLandedBlockCollider.bounds.max.x;

            float overlapLeft = Mathf.Max(currentBlockMinX, lastBlockMinX);
            float overlapRight = Mathf.Min(currentBlockMaxX, lastBlockMaxX);

            float overlapWidth = overlapRight - overlapLeft;

            if (overlapWidth <= 0.001f)
            {
                GameOver();
                return;
            }
        }
        else
        {
            isFirstBlock = false;
        }

        score++;

        UpdateScoreDisplay();
        lastLandedBlock = block;

        SpriteRenderer landedBlockRenderer = lastLandedBlock.GetComponent<SpriteRenderer>();
        if (landedBlockRenderer != null)
        {
            landedBlockRenderer.sortingOrder = score;
        }

        MoveCameraUp();

        if (score >= 9)
        {
            GameWon();
            return;
        }

        currentBlock = null;
        StartCoroutine(SpawnNextBlockWithDelay(0.1f));
    }

    void MoveCameraUp()
    {
        Vector3 camPos = mainCamera.transform.position;

        BoxCollider2D topBlockCollider = lastLandedBlock.GetComponent<BoxCollider2D>();
        if (topBlockCollider == null)
        {
            Debug.LogError("Ошибка: У lastLandedBlock отсутствует BoxCollider2D! Невозможно корректно позиционировать камеру.");
            return;
        }

        float targetCameraY = topBlockCollider.bounds.max.y + cameraOffsetFromTopBlock;

        camPos.y = targetCameraY;
        mainCamera.transform.position = camPos;
    }

    void UpdateScoreDisplay()
    {
        Debug.Log("Score: " + score);
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over! Final Score: " + score);
        Time.timeScale = 0f;
        StartCoroutine(RestartGameAfterDelay(2f));
    }

    void GameWon()
    {
        hasWon = true;
        Debug.Log("You Won! Final Score: " + score);
        Time.timeScale = 0f;
        GameData.HadLastPaper = true;
        SceneManager.LoadScene(5);
    }

    IEnumerator RestartGameAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void SpawnBlock()
    {
        if (isGameOver || hasWon) return;

        if (blockPrefab == null)
        {
            Debug.LogError("blockPrefab не назначен! Невозможно спавнить блок. Программа может остановиться.");
            return;
        }

        Vector3 spawnPosition = spawnPoint.position;
        spawnPosition.x = Random.Range(minSpawnX, maxSpawnX);

        currentBlock = Instantiate(blockPrefab, spawnPosition, Quaternion.identity);

        SpriteRenderer currentBlockRenderer = currentBlock.GetComponent<SpriteRenderer>();
        if (currentBlockRenderer != null)
        {
            currentBlockRenderer.sortingOrder = score + floatingBlockOrderOffset;
        }

        currentMoveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        movingRight = (Random.value > 0.5f);
    }

    IEnumerator SpawnNextBlockWithDelay(float delay)
    {
        if (isGameOver || hasWon) yield break;
        yield return new WaitForSeconds(delay);
        SpawnBlock();
    }

    public IEnumerator FreezeAfterDelay(Rigidbody2D rb)
    {
        yield return new WaitForSeconds(0.05f);
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    public class BlockTrigger : MonoBehaviour
    {
        public CityBloxxController controller;
        private bool hasLanded = false;

        void OnCollisionEnter2D(Collision2D col)
        {
            if (controller.isGameOver || controller.hasWon) return;

            if (col.gameObject.CompareTag("Platform") || col.gameObject.CompareTag("Block"))
            {
                if (hasLanded) return;
                hasLanded = true;

                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    StartCoroutine(controller.FreezeAfterDelay(rb));
                }

                controller.OnBlockLanded(gameObject);
            }
        }
    }
}