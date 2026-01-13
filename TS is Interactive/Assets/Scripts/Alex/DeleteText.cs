using UnityEngine;

public class DeleteText : MonoBehaviour
{
    public GameObject text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Destroy(text);
    }
}
