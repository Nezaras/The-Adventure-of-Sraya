using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementPoint : MonoBehaviour
{
    [SerializeField] ParameterKebaikan param;
    [SerializeField] int value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickupableObject") || other.CompareTag("PushableObject"))
        {
            param.current += value;
            other.tag = "PickedUpObject";
        }
    }
}
