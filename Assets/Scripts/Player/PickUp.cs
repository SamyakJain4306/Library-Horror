using UnityEngine;
using UnityEngine.InputSystem;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Animator animator;

    GameObject ovelappedItem;
    [HideInInspector] public GameObject equippedItem;
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
            animator.SetTrigger("Pick up"); // Trigger the pick-up animation
            //ovelappedItem.GetComponent<SphereCollider>().enabled = false;
            //ovelappedItem.transform.SetParent(handSocket); 
            //equippedItem.transform.localPosition = Vector3.zero; 
            //equippedItem.transform.localRotation = Quaternion.identity;
        }
    }

    void Start()
    {

        if (animator == null)
        {
            Debug.LogError("Animator component not found on the player object.");
        }
    }

    void AttachObject()
    {
        print("PickUp Attach Object called");
    }

}
