using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] NenekMovement nenekMovement;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] PickupAndDrop pickup;
    [SerializeField] DialogueManager dialogueManager;

    [SerializeField] GameObject karungNenek;
    [SerializeField] GameObject popupSuccess;

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
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogueManager.DisplayNextSentence();
        }
    }
}
