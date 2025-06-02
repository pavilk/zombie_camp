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
                new DialogueLine { speakerName = "Вася", sentence = "Извините, а на раздаче нет ни еды, ни приборов." },
                new DialogueLine { speakerName = "Вася", sentence = "Сегодня просто должны подавать мою любимую печень." },
                new DialogueLine { speakerName = "Повариха", sentence = "Фу.. Даже если бы начался зомби-апокалипсис и все люди умерли\r\nя бы предпочла стать зомби и есть мозги, вместо печени" },
                new DialogueLine { speakerName = "Повариха", sentence = "Хотя знаешь, немного печени у нас осталось, надо только найти.\r\nСделай мне пока бутерброд, там уже на доске всё готово." },
                new DialogueLine { speakerName = "Повариха", sentence = "Я ем бутерброды только с 9-ю колбасками" }
            };

            dialogueManager.StartDialogue(lines);
        }
        else
        {
            var lines = new List<DialogueLine>
            {
                new DialogueLine { speakerName = "Повариха", sentence = "Так, вот тебе свежие вчерашние макароны с печенью, а мне давай эту малышку" },
                new DialogueLine { speakerName = "Вася", sentence = "Извините, а можно я возьму немного сахара и вон ту бумажку?" },
                new DialogueLine { speakerName = "Повариха", sentence = "Если так надо - забирай, я просто салфетку не нашла." }
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
