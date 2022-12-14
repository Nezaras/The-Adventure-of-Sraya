using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    public float pushPower = 1.0F;

    private CharacterMovement movement;
    private Animator anim;

    private void Start()
    {
        movement = GetComponent<CharacterMovement>();
        anim = GetComponent<Animator>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
            return;

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3f)
            return;

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * pushPower;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PushableObject") && movement.isMove)
        {
            anim.SetBool("Push", true);
        }
        else
        {
            anim.SetBool("Push", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PushableObject"))
        {
            anim.SetBool("Push", false);
        }
    }
}
