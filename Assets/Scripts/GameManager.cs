using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] NenekMovement nenekMovement;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] PickupAndDrop pickup;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] InventoryManager inventoryManager;

    [SerializeField] GameObject karungNenek;
    [SerializeField] GameObject popupSuccess;
    [SerializeField] GameObject popupTas;
    [SerializeField] GameObject[] deactivateWhenEsc;

    public void QuestNenek()
    {
        if(pickup.pickupableObject.name == "KarungNenek")
        {
            nenekMovement.WalkingNenek();
        }
    }

    public void PickupableKarungNenek()
    {
        karungNenek.tag = "PickupableObject";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (scoreManager.isAdd)
            {
                popupSuccess.SetActive(false);

                scoreManager.AddPoint();
                scoreManager.isAdd = false;
            }
            else
            {
                foreach(GameObject a in deactivateWhenEsc)
                {
                    a.SetActive(false);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogueManager.DisplayNextSentence();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!popupTas.activeInHierarchy)
            {
                popupTas.SetActive(true);
                inventoryManager.ListItems();
            }
            else
            {
                popupTas.SetActive(false);
            }
        }
    }
}
