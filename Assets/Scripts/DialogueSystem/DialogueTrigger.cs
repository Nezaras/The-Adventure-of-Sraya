using UnityEngine;
using Cinemachine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject button;

    [SerializeField] DialogueManager manager;
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
        button.SetActive(false);
    }

    public void ShowDialogue()
    {
        manager.StartDialogue(dialogue);
        manager.DisplayNextSentence();
    }
}
