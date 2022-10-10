using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNenek : MonoBehaviour
{
    [SerializeField] ParameterKebaikan param;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickupableObject"))
        {
            param.current += 5;
            other.tag = "PickedUpObject";
        }
    }
}
