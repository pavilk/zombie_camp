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
    public static DialogueManager Instance { get; private set; }

    public GameObject dialoguePanel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.03f;
    public float fadeDuration = 0.3f;

    private CanvasGroup canvasGroup;
    private Queue<DialogueLine> dialogueLines;
    private Coroutine typingCoroutine;

    public bool IsDialoguePlaying { get; private set; } = false;
    private bool isTyping = false;
    private string currentSentence = "";

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        dialogueLines = new Queue<DialogueLine>();
        canvasGroup = dialoguePanel.GetComponent<CanvasGroup>();
        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(List<DialogueLine> lines)
    {
        dialogueLines.Clear();

        foreach (var line in lines)
            dialogueLines.Enqueue(line);

        IsDialoguePlaying = true;
        dialoguePanel.SetActive(true);

        StartCoroutine(FadeIn(() =>
        {
            DisplayNextLine();
        }));
    }

    public void DisplayNextLine()
    {
        if (isTyping)
        {
            // Прерываем печать и сразу выводим всю фразу
            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);

            dialogueText.text = currentSentence;
            isTyping = false;
            return;
        }

        if (dialogueLines.Count == 0)
        {
            StartCoroutine(FadeOut(() =>
            {
                dialoguePanel.SetActive(false);
                IsDialoguePlaying = false;
            }));
            return;
        }

        DialogueLine line = dialogueLines.Dequeue();
        nameText.text = line.speakerName;

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeSentence(line.speakerName + ": " + line.sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        currentSentence = sentence;
        dialogueText.text = "";

        foreach (char letter in sentence)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
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
