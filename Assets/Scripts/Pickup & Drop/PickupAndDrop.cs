using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndDrop : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Transform handCharacter;
    [SerializeField] DialogueTrigger dialogueNenek;

    bool _canPickup;
    bool _hasItem;
    
    [HideInInspector]
    public GameObject pickupableObject;
   
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
                pickupableObject.GetComponent<Rigidbody>().isKinematic = true;
                pickupableObject.transform.position = handCharacter.transform.position;
                pickupableObject.transform.parent = handCharacter.transform;

                pickupableObject.tag = "PickedUpObject";                

                _hasItem = true;

                gameManager.QuestNenek();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && _hasItem == true)
        {
            pickupableObject.GetComponent<Rigidbody>().isKinematic = false;
            pickupableObject.transform.parent = null;

            pickupableObject.tag = "PickupableObject";

            dialogueNenek.ShowDialogue();

            _hasItem = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickupableObject"))
        {
            _canPickup = true;
            pickupableObject = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _canPickup = false;
    }
}
