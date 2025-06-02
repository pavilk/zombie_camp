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
                new DialogueLine { speakerName = "����", sentence = "���, ������� � ������. � �����!" },
                new DialogueLine { speakerName = "����", sentence = "." },
                new DialogueLine { speakerName = "����", sentence = "������, ����� ������ ������� � ������� ������ ���������� �� ����." },
                new DialogueLine { speakerName = "����", sentence = "..." },
                new DialogueLine { speakerName = "����", sentence = "���, ��� ����� �� ������, ������ ��� �������... ���� ���� ����." },
                new DialogueLine { speakerName = "����", sentence = "...." }
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
