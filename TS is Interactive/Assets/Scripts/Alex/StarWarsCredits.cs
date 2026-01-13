using UnityEngine;

public class StarWarsCredits : MonoBehaviour
{
    public float scrollSpeed = 1f;
    public float backSpeed = 1f;

    void Update()
    {
        // Move up
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime, Space.World);

        transform.Translate(Vector3.forward * backSpeed * Time.deltaTime, Space.World);
    }
}
