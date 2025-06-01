using UnityEngine;
using System.Collections;

public class FirstPinScript : MonoBehaviour
{
    public static bool Fixed = false;
    public static bool RightSequence = false;

    private static Rigidbody2D PinBody;
    private static Collider2D pinCollider;

    private Collider2D scriptBlockCollider;

    private static FirstPinScript instance;

    private void Awake()
    {
        scriptBlockCollider = GetComponent<Collider2D>();
        instance = this; // сохраняем ссылку на экземпляр
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "otmichka" || !scriptBlockCollider.enabled)
            return;

        pinCollider = collision;
        PinBody = collision.attachedRigidbody;

        PinBody.bodyType = RigidbodyType2D.Static;
        Fixed = true;

        if (SecondPinScript.Fixed && !ThirdPinScript.Fixed)
        {
            RightSequence = true;
        }
        else
        {
            RightSequence = false;
        }
    }

    public static void Reset()
    {
        // Запускаем корутину через экземпляр
        instance.StartCoroutine(instance.DisableTriggerTemporarily(2f));

        // Отталкиваем пин
        if (pinCollider != null)
        {
            pinCollider.transform.position += new Vector3(0f, -0.05f, 0f);
        }

        if (PinBody != null)
        {
            PinBody.bodyType = RigidbodyType2D.Dynamic;
        }

        Fixed = false;
        RightSequence = false;
    }

    private IEnumerator DisableTriggerTemporarily(float seconds)
    {
        scriptBlockCollider.enabled = false;
        yield return new WaitForSeconds(seconds);
        scriptBlockCollider.enabled = true;
    }
}
