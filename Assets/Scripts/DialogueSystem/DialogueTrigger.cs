using UnityEngine;
using Cinemachine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject button;

    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] Dialogue dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            button.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            button.SetActive(false);
        }
    }

    public void ShowDialogue()
    {
        dialogueManager.StartDialogue(dialogue);
        dialogueManager.DisplayNextSentence();
    }
}
