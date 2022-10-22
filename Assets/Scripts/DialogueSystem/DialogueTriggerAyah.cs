using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Cinemachine;

public class DialogueTriggerAyah : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject pipeManage;

    [SerializeField] Transform sraya;
    [SerializeField] Transform npc;

    [SerializeField] GameObject item1;
    [SerializeField] GameObject item2;
    [SerializeField] GameObject item3;
    [SerializeField] GameObject StatusUang;

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

        if(pipeManage.GetComponent<PipeManager>().isDone){
            dialogueManager.StartDialogue(dialogueFinish);
            dialogueManager.DisplayNextSentence();

            item1.GetComponent<Button>().interactable = true;
            item2.GetComponent<Button>().interactable = true;
            item3.GetComponent<Button>().interactable = true;

            StatusUang.GetComponent<Text>().text = "Jumlah Uang: Rp.80.000,-";

           scoreManager.GetComponent<ScoreManager>().isAdd = true;
        }
    }
}
