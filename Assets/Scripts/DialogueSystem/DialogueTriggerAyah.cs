using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Cinemachine;

public class DialogueTriggerAyah : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    [SerializeField] Transform sraya;
    [SerializeField] Transform npc;

    [SerializeField] GameManager gameManager;
    [SerializeField] PipeManager pipeManager;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] Dialogue dialogueNormal;
    [SerializeField] Dialogue dialogueFinish;

    [SerializeField] GameObject item1;
    [SerializeField] GameObject item2;
    [SerializeField] GameObject item3;
    [SerializeField] GameObject uang;

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

        if(pipeManager.isDone){
            dialogueManager.StartDialogue(dialogueFinish);
            dialogueManager.DisplayNextSentence();

           scoreManager.GetComponent<ScoreManager>().isAdd = true;

            item1.GetComponent<Button>().interactable = true;
            item2.GetComponent<Button>().interactable = true;
            item3.GetComponent<Button>().interactable = true;

            uang.transform.Find("TotalUang").GetComponent<Text>().text = "Jumlah Uang: Rp.80000";
        }
    }
}
