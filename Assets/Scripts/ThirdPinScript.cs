using UnityEngine;
using System.Collections;

public class ThirdPinScript : MonoBehaviour
{
    public static bool Fixed = false;
    public static bool RightSequence = false;

    private static Rigidbody2D PinBody;
    private static Collider2D myCollider;

    private Collider2D scriptBlockCollider;

    private static ThirdPinScript instance;

    private void Awake()
    {
        scriptBlockCollider = GetComponent<Collider2D>();
        instance = this; // сохраняем ссылку на экземпляр
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "otmichka" || !scriptBlockCollider.enabled)
            return;

        myCollider = collision;
        PinBody = collision.attachedRigidbody;

        PinBody.bodyType = RigidbodyType2D.Static;
        Fixed = true;

        if (SecondPinScript.Fixed && FirstPinScript.Fixed)
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
        if (myCollider != null)
        {
            myCollider.transform.position += new Vector3(0f, -0.05f, 0f);
        }

        if (PinBody != null)
        {
            PinBody.bodyType = RigidbodyType2D.Dynamic;
        }

        Fixed = false;
        RightSequence = false;

        // Запускаем корутину через экземпляр
        instance.StartCoroutine(instance.DisableTriggerTemporarily(2f));
    }

    private IEnumerator DisableTriggerTemporarily(float seconds)
    {
        scriptBlockCollider.enabled = false;
        yield return new WaitForSeconds(seconds);
        scriptBlockCollider.enabled = true;
    }
}
