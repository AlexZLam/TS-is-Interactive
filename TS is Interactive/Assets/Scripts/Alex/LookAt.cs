using UnityEngine;

public class TriggerLookAt : MonoBehaviour
{
    public LookAtPlayer targetObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetObject.StartRotationAnimation();
        }
    }
}
