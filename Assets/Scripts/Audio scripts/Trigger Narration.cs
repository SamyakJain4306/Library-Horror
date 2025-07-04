using UnityEngine;

public class Trigger1 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        GetComponent<AudioSource>().enabled = true;
    }
}

}
