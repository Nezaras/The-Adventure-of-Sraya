using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementPoint : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] TimerManager timerManager;

    [SerializeField] int value;

    public bool isRightPlace;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickupableObject") || other.CompareTag("PushableObject"))
        {
            scoreManager.isAdd = true;

            timerManager.isWin = true;
            timerManager.isLose = false;

            isRightPlace = true;
            other.tag = "PickedUpObject";
        }
    }
}
