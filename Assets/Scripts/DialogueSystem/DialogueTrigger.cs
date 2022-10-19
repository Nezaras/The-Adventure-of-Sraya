using UnityEngine;
using Cinemachine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject button;

    [SerializeField] Transform sraya;
    [SerializeField] Transform npc;

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
        sraya.transform.LookAt(npc);

        dialogueManager.StartDialogue(dialogue);
        dialogueManager.DisplayNextSentence();
    }
}
