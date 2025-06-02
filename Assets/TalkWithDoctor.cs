using UnityEngine;
using System.Collections.Generic;

public class TalkWithDoctor : MonoBehaviour
{
    public Transform FirstTarget;
    public Transform SecondTarget;
    public Transform ThirdTarget;
    public CompassArrowController compass;

    private void OnTriggerEnter2D(Collider2D other){

        var dialogueManager = DialogueManager.Instance;
        if (!PushLever.CanPush && !SwitchToCoridor.CanGoBack)
        {
            var lines = new List<DialogueLine>
            {
                new DialogueLine { speakerName = "����", sentence = "������������! � �� �� ������, ���� ������� ��� ���� � �������" },
                new DialogueLine { speakerName = "������", sentence = "������? ����������. ������ ������� �� �������?" },
                new DialogueLine { speakerName = "������", sentence = "���� �� �����, � ������ ������� ������, ��� ��� ��� � ���������." },
                new DialogueLine { speakerName = "����", sentence = "������? � ��� ����� ���� ���� � ��������? " },
                new DialogueLine { speakerName = "������", sentence = "��.. ��� ��� ��� ����, ��� ��� ����������� ������� � ������ � ������ � ����� �������." },
                new DialogueLine { speakerName = "����", sentence = "��������" },
                new DialogueLine { speakerName = "������", sentence = "� � ��� �����-�� ����� ������� ������ �� �������������� �����, � ��� ���� ������� ��� ����." },
                new DialogueLine { speakerName = "������", sentence = "���� ������ �����-�� �������� ��������, �� ���� �� ����. ��, �����." }
            };

            dialogueManager.StartDialogue(lines);
            compass.SetTarget(FirstTarget);
        }

        else if (!PushLever.CanPush)
        {
            var lines = new List<DialogueLine>
            {
                new DialogueLine { speakerName = "����", sentence = "� �� ���� ���������� � �������, ���, ��� � ������� ����� �����" },
                new DialogueLine { speakerName = "����", sentence = "������ ��� �����!!!" },
                new DialogueLine { speakerName = "������", sentence = "�� ����� ��� ��������� �������??, �� ��������. ���, � ��� ��� � ���� � �����?" },
                new DialogueLine { speakerName = "����", sentence = "� ��, � ����� ������� ��� ��� ����� � ���." },
                new DialogueLine { speakerName = "������", sentence = "��� ������, �� ���.." },
                new DialogueLine { speakerName = "������", sentence = "��. �������!" },
                new DialogueLine { speakerName = "������", sentence = "������, � �� ������� �� ����� ������� � ������ �� ���������?" },
                new DialogueLine { speakerName = "������", sentence = "��� �� ������ ������� ������, ������� ��� ������, � ������� ���������� ���, ��������?" },
                new DialogueLine { speakerName = "����", sentence = "������, �������� �� ����� �����. ������ ���������� �������� ����.\r\n�� ��� ����� ��� ����, �� � ��� ��� ����� ������ � ��� � ��������� �� ������ ��������..." },
                new DialogueLine { speakerName = "?", sentence = "� ����, ���� ����� ��� ��������� ������." },
                new DialogueLine { speakerName = "������", sentence = "�����, �������, �����!" }
            };

            dialogueManager.StartDialogue(lines);
            compass.SetTarget(SecondTarget);
        }
        else
        {
            var lines = new List<DialogueLine>
            {
                new DialogueLine { speakerName = "����", sentence = "�-�-��������, ��� ���, ��� ������ ����� ��, ������ �� ����� �����, ������..\r\n�� �����, �� ������� �� ����, � ������ ������� ��������, � ����\r\n" },
                new DialogueLine { speakerName = "������", sentence = "���, ����� ������� �������. ��� ����, ������ �� ����� � ����� �� �� �����.\r\n��, ��� ���� �������. ��� � �������� ���� �� �����, �����, ����� ��� ����� �������..\r\n�������! � �����, � �����!\r\n" },
                new DialogueLine { speakerName = "����", sentence = "���, �� � �������� ��� ����� ������ �� ������, ��-���� �������� � ��� ������!\r\n" }
               
            };

            dialogueManager.StartDialogue(lines);
            compass.SetTarget(ThirdTarget);
        }
        if (GameData.HadLastPaper)
        {
            var lines = new List<DialogueLine>
            {
                new DialogueLine { speakerName = "����", sentence = "������������! ������� ����� � ��������� ����� �������, ���� �� �����!" },
                new DialogueLine { speakerName = "������", sentence = "�������! � ������� ��������, ��� �� ������ ��� ������������ ������������ ��������!" },
                new DialogueLine { speakerName = "������", sentence = "������� �������� � ��������, ������ �� ������ �������!\r\n����� ������ � � �������� ����� �������� �� ������" },
                new DialogueLine { speakerName = "������", sentence = "� ��� �� �����������?" },
                new DialogueLine { speakerName = "������", sentence = "����������� ���, �������� ����. �� �������� ���������� �����������!" },
                new DialogueLine { speakerName = "������", sentence = "���������� ���������, ��������� ���������� ����� � �������� ��������" },
                new DialogueLine { speakerName = "������", sentence = "��-��-��-��-��-��" }

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
