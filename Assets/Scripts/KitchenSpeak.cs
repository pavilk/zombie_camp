using UnityEngine;
using System.Collections.Generic;

public class KitchenSpeak : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var dialogueManager = DialogueManager.Instance;
        if (!GameData.HadLastPaper)
        {
            var lines = new List<DialogueLine>
            {
                new DialogueLine { speakerName = "����", sentence = "��������, � �� ������� ��� �� ���, �� ��������." },
                new DialogueLine { speakerName = "����", sentence = "������� ������ ������ �������� ��� ������� ������." },
                new DialogueLine { speakerName = "��������", sentence = "��.. ���� ���� �� ������� �����-����������� � ��� ���� ������\r\n� �� ��������� ����� ����� � ���� �����, ������ ������" },
                new DialogueLine { speakerName = "��������", sentence = "���� ������, ������� ������ � ��� ��������, ���� ������ �����.\r\n������ ��� ���� ���������, ��� ��� �� ����� �� ������." },
                new DialogueLine { speakerName = "��������", sentence = "� �� ���������� ������ � 9-� ����������" }
            };

            dialogueManager.StartDialogue(lines);
        }
        else
        {
            var lines = new List<DialogueLine>
            {
                new DialogueLine { speakerName = "��������", sentence = "���, ��� ���� ������ ��������� �������� � �������, � ��� ����� ��� �������" },
                new DialogueLine { speakerName = "����", sentence = "��������, � ����� � ������ ������� ������ � ��� �� �������?" },
                new DialogueLine { speakerName = "��������", sentence = "���� ��� ���� - �������, � ������ �������� �� �����." }
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
