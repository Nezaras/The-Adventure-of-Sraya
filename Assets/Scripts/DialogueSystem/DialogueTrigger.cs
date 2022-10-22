using UnityEngine;
using Cinemachine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    [SerializeField] Transform sraya;
    [SerializeField] Transform npc;

    [SerializeField] GameManager gameManager;
    [SerializeField] Dialogue dialogueNormal;
    [SerializeField] Dialogue dialogueFinish;
    [SerializeField] DialogueManager dialogueManager;

    [SerializeField] GameObject scoreManager;
    [SerializeField] GameObject trigger;

    [SerializeField] bool isNenek;

    bool isNear;
    public bool isFirst = true;

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
            Debug.Log("Dialog Nenek");
            ShowDialogue();
            canvas.SetActive(false);
            trigger.SetActive(false);

            gameManager.PickupableKarungNenek();
            isNear = false;
        }
    }

    public void ShowDialogue()
    {
        sraya.transform.LookAt(npc);

        if(isFirst){
            dialogueManager.StartDialogue(dialogueNormal);
            dialogueManager.DisplayNextSentence();

            if (!isNenek)
            {
                isFirst = false;
            }
        }
        else{
            dialogueManager.StartDialogue(dialogueFinish);
            dialogueManager.DisplayNextSentence();
            scoreManager.GetComponent<ScoreManager>().isAdd = true;
        }
    }
}
