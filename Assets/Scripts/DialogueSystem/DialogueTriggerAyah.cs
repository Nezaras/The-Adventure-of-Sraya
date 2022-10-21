using UnityEngine;
using Cinemachine;

public class DialogueTriggerAyah : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    [SerializeField] Transform sraya;
    [SerializeField] Transform npc;

    [SerializeField] GameManager gameManager;
    [SerializeField] Dialogue dialogueNormal;
    [SerializeField] Dialogue dialogueFinish;

    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] GameObject scoreManager;

    bool isNear;
    bool isFirst = true;

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

            //gameManager.PickupableKarungNenek();
            //gameObject.SetActive(false);
        }
    }

    public void ShowDialogue()
    {
        sraya.transform.LookAt(npc);

        if(isFirst){
            dialogueManager.StartDialogue(dialogueNormal);
            dialogueManager.DisplayNextSentence();
            GameObject.Find("Torrent").transform.GetChild(2).gameObject.SetActive(true);
            isFirst = false;
        }

        if(GameObject.Find("Canvas").transform.GetChild(6).gameObject.transform.GetChild(2).gameObject.GetComponent<PipeManager>().isDone){
            dialogueManager.StartDialogue(dialogueFinish);
            dialogueManager.DisplayNextSentence();

           scoreManager.GetComponent<ScoreManager>().isAdd = true;
        }
    }
}
