using UnityEngine;
using System.Collections.Generic;

public class KnifesMonolog : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        var dialogueManager = DialogueManager.Instance;

        var lines = new List<DialogueLine>
            {
                new DialogueLine { speakerName = "Вася", sentence = "Пупупу… Кто-то очень не хочет отдавать сахар" },
            };

        dialogueManager.StartDialogue(lines);
        other.isTrigger = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && DialogueManager.Instance.IsDialoguePlaying)
        {
            DialogueManager.Instance.DisplayNextLine();
        }

    }
}
