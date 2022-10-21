using UnityEngine;
using Cinemachine;

public class DialogueTrigger2Condition : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    [SerializeField] Transform sraya;
    [SerializeField] Transform npc;

    [SerializeField] GameManager gameManager;
    [SerializeField] Dialogue dialogueNormal;
    [SerializeField] Dialogue dialogueAdaBarang;
    [SerializeField] Dialogue dialogueTidakAdaBarang;

    [SerializeField] DialogueManager dialogueManager;

    public GameObject inventoryManager;
    public GameObject scoreManager;

    private bool isFirst = true;

    bool isNear;
    bool contain;

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
            isFirst = false;
        }
        else{
            foreach (Item item in inventoryManager.GetComponent<InventoryManager>().Items){
                if(item.itemName.Contains("Roti")){
                    contain = true;
                }
                //Debug.Log(item.itemName.Contains("Roti"));
            }

            if(contain){
                dialogueManager.StartDialogue(dialogueAdaBarang);
                dialogueManager.DisplayNextSentence();

                scoreManager.GetComponent<ScoreManager>().isAdd = true;
                //popupSuccess.translate.GetComponent<ScoreManager>.isAdd = true;
            }
            else{
                dialogueManager.StartDialogue(dialogueTidakAdaBarang);
                dialogueManager.DisplayNextSentence();
            }
        }
    }
}
