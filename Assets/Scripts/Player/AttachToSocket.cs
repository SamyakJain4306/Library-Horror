using UnityEngine;

public class AttachToSocket : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public PickUp pickUp; // Reference to the PickUp script
    void Attach()
    {
        if (pickUp == null)
        {
            Debug.LogError("PickUp script reference is not set in AttachToSocket.");
            return;
        }
        print("Attach called");
        if (pickUp.equippedItem != null)
        {
            // Disable the collider of the equipped item
            SphereCollider sphereCollider = pickUp.equippedItem.GetComponent<SphereCollider>();
            if (sphereCollider != null)
            {
                sphereCollider.enabled = false;
            }
            // Set the parent of the equipped item to the hand socket
            pickUp.equippedItem.transform.SetParent(pickUp.handSocket);
            // Reset the local position and rotation of the equipped item
            pickUp.equippedItem.transform.localPosition = Vector3.zero;
            pickUp.equippedItem.transform.localRotation = Quaternion.identity;
        }
    }
}
