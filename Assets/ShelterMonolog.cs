using UnityEngine;
using System.Collections.Generic;

public class ShelterMonolog : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        var dialogueManager = DialogueManager.Instance;

            var lines = new List<DialogueLine>
            {
                new DialogueLine { speakerName = "����", sentence = "��� ������, ��� � ���� ���� ������ � ��������� - ������� �� ������, ����� ����������" },
            };

            dialogueManager.StartDialogue(lines);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && DialogueManager.Instance.IsDialoguePlaying)
        {
            DialogueManager.Instance.DisplayNextLine();
        }

    }
}
