using UnityEngine;
using System.Collections;

public class MovementDisabler : MonoBehaviour
{
    public MonoBehaviour movementScript;
    public MonoBehaviour footstepScript;
    public AudioSource breathing;

    void Start()
    {
        StartCoroutine(EnableMovementAfterDelay(29f));
    }

    IEnumerator EnableMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        movementScript.enabled = true;
        footstepScript.enabled = true;
        breathing.enabled = true;

    }
}
