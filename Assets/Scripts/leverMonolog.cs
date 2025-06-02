using UnityEngine;
using System.Collections.Generic;

public class leverMonolog : MonoBehaviour
{
    private static bool played = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!played)
        {
            var dialogueManager = DialogueManager.Instance;

            var lines = new List<DialogueLine>
            {
                new DialogueLine { speakerName = "Вася", sentence = "Так, бумажку я возьму. О рычаг!" },
                new DialogueLine { speakerName = "Вася", sentence = "." },
                new DialogueLine { speakerName = "Вася", sentence = "Видимо, нужно просто подойти и ооочень близко посмотреть на него." },
                new DialogueLine { speakerName = "Вася", sentence = "..." },
                new DialogueLine { speakerName = "Вася", sentence = "Так, тут такой же пионер, только уже зеленый... надо быть тише." },
                new DialogueLine { speakerName = "Вася", sentence = "...." }
            };
            played = true;
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
