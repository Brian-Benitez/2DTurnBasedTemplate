using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

[System.Serializable]
public class DialogueLine
{
    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> DialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    [Header("Booleans")]
    public bool RestartDialouge = true;

    [Header("Buttons")]
    public KeyCode InteractKeyCode = KeyCode.E;

    [Header("Dialouges lines")]
    public Dialogue Dialogue;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(Dialogue);
    }

    private void Update()
    {
        if(!RestartDialouge && UnityEngine.Input.GetKeyUp(InteractKeyCode))
            return;
        if(DialogueManager.Instance.isDialogueActive && UnityEngine.Input.GetKeyUp(InteractKeyCode))
        {
            RestartDialouge = false;
            Debug.Log("start dialouge");
            TriggerDialogue();
        }
        if(DialogueManager.Instance.isDialogueActive && UnityEngine.Input.GetKeyUp(KeyCode.Space) || UnityEngine.Input.GetMouseButtonUp(0))
        {
            DialogueManager.Instance.DisplayNextDialogueLine();
            CheckList();
        }
    }


    void CheckList()
    {
        if (Dialogue.DialogueLines.Count == DialogueManager.Instance.SentencesCount && DialogueManager.Instance.isDialogueActive)
        {
            RestartDialouge = true;
            DialogueManager.Instance.SentencesCount = 0;
        }
        else if(DialogueManager.Instance.SentencesCount < Dialogue.DialogueLines.Count && DialogueManager.Instance.isDialogueActive)
            RestartDialouge = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DialogueManager.Instance.isDialogueActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            DialogueManager.Instance.isDialogueActive = false;
        }
    }
}