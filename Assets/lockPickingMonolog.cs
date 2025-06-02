using UnityEngine;
using System.Collections.Generic;

public class lockPickingMonolog : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        var dialogueManager = DialogueManager.Instance;
        if (!PushLever.CanPush && !SwitchToCoridor.CanGoBack)
        {
            var lines = new List<DialogueLine>
            {
                new DialogueLine { speakerName = "Вася", sentence = "Стоп, а почему дверь закрыта, я же только что вышел." },
                new DialogueLine { speakerName = "Вася", sentence = "..." },
                new DialogueLine { speakerName = "Вася", sentence = "Хорошо, что в моём родном Гусе Хрустальном я ходил на кружок юного взломщика" }
            };

            dialogueManager.StartDialogue(lines);
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
