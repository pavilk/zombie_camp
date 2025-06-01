using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class DialogueLine
{
    public string speakerName;
    [TextArea(2, 5)]
    public string sentence;
}

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.03f;
    public float fadeDuration = 0.3f;

    private CanvasGroup canvasGroup;
    private Queue<DialogueLine> dialogueLines;
    private Coroutine typingCoroutine;

    void Awake()
    {
        dialogueLines = new Queue<DialogueLine>();
        canvasGroup = dialoguePanel.GetComponent<CanvasGroup>();
        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(List<DialogueLine> lines)
    {
        dialoguePanel.SetActive(true);
        dialogueLines.Clear();

        foreach (var line in lines)
            dialogueLines.Enqueue(line);

        StartCoroutine(FadeIn(() =>
        {
            DisplayNextLine();
        }));
    }

    public void DisplayNextLine()
    {
        if (dialogueLines.Count == 0)
        {
            StartCoroutine(FadeOut(() =>
            {
                dialoguePanel.SetActive(false);
            }));
            return;
        }

        DialogueLine line = dialogueLines.Dequeue();

        nameText.text = line.speakerName;

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeSentence(line.sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator FadeIn(System.Action onComplete = null)
    {
        canvasGroup.alpha = 0f;
        float time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(time / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 1f;
        onComplete?.Invoke();
    }

    IEnumerator FadeOut(System.Action onComplete = null)
    {
        float time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = 1f - Mathf.Clamp01(time / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 0f;
        onComplete?.Invoke();
    }
}
