using UnityEngine;
using System.Collections.Generic;

public class PushLever : MonoBehaviour
{
    public Sprite newSprite;
    private SpriteRenderer spriteRenderer;
    public static bool CanPush = false;
    public static bool PushedAlready = false;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (spriteRenderer != null && CanPush && other.tag == "Player")
        {
            if (newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
                PushedAlready = true;
                EnemyAI.Animator.SetBool("Pushed", true);
                var dialogueManager = DialogueManager.Instance;
                var lines = new List<DialogueLine>
            {
                new DialogueLine { speakerName = "«ŒÃ¡›", sentence = "”›”›”›”›”›" },
                new DialogueLine { speakerName = "", sentence = "" },
                new DialogueLine { speakerName = "¬‡Òˇ", sentence = "¿¿¿¿¿ Œœﬂ“‹ «ŒÃ¡›" }
            };

                dialogueManager.StartDialogue(lines);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && DialogueManager.Instance.IsDialoguePlaying)
        {
            DialogueManager.Instance.DisplayNextLine();
        }

    }
}
