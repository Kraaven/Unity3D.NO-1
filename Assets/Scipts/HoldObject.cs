using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObject : MonoBehaviour
{
    public float interactDistance = 3f;
    public Transform cameraTransform; // The player's camera transform.
    public float holdDistance = 2f; // The distance between the camera and the held object.

    private GameObject heldObject;
    private bool isHolding;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHolding)
                DropObject();
            else
                PickUpObject();
        }

        if (isHolding && heldObject != null)
            MoveHeldObject();
    }

    private void PickUpObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, interactDistance))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.GetComponent<ObjectInfo>().BePickedUp)
            {
                // Disable the Rigidbody while holding the object to avoid physics issues.
                Rigidbody rb = hitObject.GetComponent<Rigidbody>();
                if (rb != null)
                    rb.isKinematic = true;

                // Parent the object to the camera.
                heldObject = hitObject;
                heldObject.transform.SetParent(cameraTransform);

                // Adjust position and rotation to make it look like the object is held in front of the player.
                heldObject.transform.localPosition = new Vector3(0f, 0f, holdDistance);
                Quaternion heldobject = Quaternion.Euler(new Vector3(heldObject.GetComponent<ObjectInfo>().rotx,heldObject.GetComponent<ObjectInfo>().roty,heldObject.GetComponent<ObjectInfo>().rotz));
                heldObject.transform.localRotation = heldobject;

                isHolding = true;
            }
        }
    }

    private void DropObject()
    {
        if (heldObject != null)
        {
            // Enable the Rigidbody to restore physics simulation.
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();
            if (rb != null)
                rb.isKinematic = false;

            // Unparent the object from the camera.
            heldObject.transform.SetParent(null);

            heldObject = null;
            isHolding = false;
        }
    }

    private void MoveHeldObject()
    {
        // You may want to add additional logic for object movement, rotation, etc.
        // For example, you could implement smooth movement to make the object follow the camera smoothly.
    }
}
