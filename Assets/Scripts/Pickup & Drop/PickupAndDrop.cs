using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndDrop : MonoBehaviour
{
    private Animator anim;

    [SerializeField] GameManager gameManager;
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] Transform handCharacter;
    [SerializeField] DialogueTrigger dialogueNenek;
    [SerializeField] PlacementPoint placement;

    bool _canPickup;
    public bool hasItem;
    
    [HideInInspector]
    public GameObject pickupableObject;

    public bool canDrop;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        _canPickup = false;
        hasItem = false;
    }

    void Update()
    {
        if (_canPickup)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {                
                StartCoroutine(PickUp());
                boxCollider.enabled = false;
            }
        }

        if (canDrop)
        {
            if (Input.GetKeyDown(KeyCode.Q) && hasItem == true)
            {
                Drop();
            }
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

    IEnumerator PickUp()
    {
        anim.SetTrigger("Pickup");

        yield return new WaitForSeconds(0.55f);

        anim.SetTrigger("MovingGrab");

        pickupableObject.GetComponent<Rigidbody>().isKinematic = true;
        pickupableObject.transform.position = handCharacter.transform.position;
        pickupableObject.transform.parent = handCharacter.transform;

        pickupableObject.tag = "PickedUpObject";
        hasItem = true;

        gameManager.QuestNenek();
    }

    void Drop()
    {
        anim.SetTrigger("BackToMovement");

        pickupableObject.GetComponent<Rigidbody>().isKinematic = false;
        pickupableObject.transform.parent = null;

        pickupableObject.tag = "PickupableObject";

        boxCollider.enabled = true;
        hasItem = false;

        if (placement.isRightPlace)
        {
            dialogueNenek.ShowDialogue();
        }
    }
}
