using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SwitchToCoridor : MonoBehaviour
{
    static public bool CanGoBack = false;

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (CanGoBack)
            SceneManager.LoadScene(2);
        else
        {
            var dialogueManager = DialogueManager.Instance;
            var lines = new List<DialogueLine>
            {
                new DialogueLine { speakerName = "����", sentence = "�, �������! �, ����!" },
                new DialogueLine { speakerName = "����", sentence = "׸� ��� ���-�� ���������" },
                new DialogueLine { speakerName = "�����-����", sentence = "��������!!!" },
                new DialogueLine { speakerName = "����", sentence = "�����, ����� ������" }
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
