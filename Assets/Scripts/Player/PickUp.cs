using UnityEngine;
using UnityEngine.InputSystem;

public class PickUp : MonoBehaviour
{
    GameObject ovelappedItem;
    GameObject equippedItem;
    public Transform handSocket;

    public static PlayerInputHandler Instance { get; private set; }

    public void SetOverlappingItem(GameObject item)
    {
        ovelappedItem = item; // Store the overlapping item for later use
    }

    void OnEnable()
    {
        PlayerInputHandler.Instance.InteractAction.performed += OnInteract;
    }

    void OnDisable()
    {
        //PlayerInputHandler.Instance.InteractAction.performed -= OnInteract;
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (ovelappedItem != null)
        {
            equippedItem = ovelappedItem;
            ovelappedItem.GetComponent<SphereCollider>().enabled = false;
            ovelappedItem.transform.SetParent(handSocket); 
            equippedItem.transform.localPosition = Vector3.zero; 
            equippedItem.transform.localRotation = Quaternion.identity;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
