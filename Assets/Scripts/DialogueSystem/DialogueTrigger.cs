using UnityEngine;
using Cinemachine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    [SerializeField] Transform sraya;
    [SerializeField] Transform npc;

    [SerializeField] GameManager gameManager;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] Dialogue dialogue;

    bool isNear;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = true;
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
            canvas.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && isNear)
        {
            ShowDialogue();
            canvas.SetActive(false);

            gameManager.PickupableKarungNenek();
            gameObject.SetActive(false);
        }
    }

    public void ShowDialogue()
    {
        sraya.transform.LookAt(npc);

        dialogueManager.StartDialogue(dialogue);
        dialogueManager.DisplayNextSentence();
    }
}
