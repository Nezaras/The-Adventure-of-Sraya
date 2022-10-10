using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndDrop : MonoBehaviour
{
    [SerializeField] Transform handCharacter;

    bool _canPickup;
    bool _hasItem;
    GameObject _pickupableObject;
   
    void Start()
    {
        _canPickup = false;
        _hasItem = false;
    }

    void Update()
    {
        if (_canPickup)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _pickupableObject.GetComponent<Rigidbody>().isKinematic = true;
                _pickupableObject.transform.position = handCharacter.transform.position;
                _pickupableObject.transform.parent = handCharacter.transform;

                _pickupableObject.tag = "PickedUpObject";

                _hasItem = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && _hasItem == true)
        {
            _pickupableObject.GetComponent<Rigidbody>().isKinematic = false;
            _pickupableObject.transform.parent = null;

            _pickupableObject.tag = "PickupableObject";

            _hasItem = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickupableObject"))
        {
            _canPickup = true;
            _pickupableObject = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _canPickup = false;
    }
}
