using UnityEngine;
using System.Collections.Generic;

public class leverMonolog : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        var dialogueManager = DialogueManager.Instance;

        var lines = new List<DialogueLine>
            {
                new DialogueLine { speakerName = "Вася", sentence = "Так, бумажку я возьму. О рычаг!" },
                new DialogueLine { speakerName = "Вася", sentence = "Видимо, нужно просто подойти и ооочень близко посмотреть на него." },
                new DialogueLine { speakerName = "Вася", sentence = "Так, тут такой же пионер, только уже зеленый... надо быть тише." }
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
