using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public GameObject butterPrefab; 
    public float moveSpeed = 5f;
    public float butterSpreadInterval = 0.1f;
    private float butterTimer = 0f;
    private bool isSpreading = false;
    private float breadWidth = 2f;
    private float leftBound;
    private float rightBound;

    void Start()
    {
        leftBound = -breadWidth / 2;
        rightBound = breadWidth / 2;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isSpreading = true;
            var moveInput = Input.GetAxisRaw("Horizontal");
            var newPosition = transform.position + Vector3.right * moveInput * moveSpeed * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, leftBound, rightBound);
            transform.position = newPosition;
        }
        else
        {
            isSpreading = false;
        }

        if (isSpreading)
        {
            butterTimer += Time.deltaTime;
            if (butterTimer >= butterSpreadInterval)
            {
                SpreadButter();
                butterTimer = 0f;
            }
        }
    }

    void SpreadButter()
    {
        var butterPosition = transform.position + Vector3.down * 0.2f;
        Instantiate(butterPrefab, butterPosition, Quaternion.identity);
    }
}