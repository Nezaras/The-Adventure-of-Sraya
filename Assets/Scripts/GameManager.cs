using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] NenekMovement nenekMovement;
    [SerializeField] PickupAndDrop pickup;
    [SerializeField] GameObject karungNenek;

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
}
