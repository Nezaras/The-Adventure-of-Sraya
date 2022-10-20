using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementPoint : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;

    [SerializeField] int value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickupableObject") || other.CompareTag("PushableObject"))
        {
            scoreManager.isAdd = true;
            other.tag = "PickedUpObject";
        }
    }
}
