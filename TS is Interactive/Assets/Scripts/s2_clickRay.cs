using UnityEngine;

public class s2_clickRay : MonoBehaviour
{
    public float maxDistance = 10f;
    public Camera pov_camera;
    private Vector3 origin;
    private Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Declare a variable to store information about the hit
        RaycastHit hit;

        // Origin point (e.g., the object's position) and direction (e.g., forward)
        origin = pov_camera.transform.position;
        direction = pov_camera.transform.forward;

        // Perform the raycast
        // This function returns true if a collider is hit, and populates the 'hit' variable
        if (Physics.Raycast(origin, direction, out hit, maxDistance))
        {
            // The ray hit an object! Access information via the 'hit' variable.
            Debug.Log("Hit object: " + hit.transform.name);
            Debug.Log("Hit point: " + hit.point); // The exact world position of the hit
        }
        else
        {
            // The ray did not hit any object within the maxDistance
            Debug.Log("Ray missed.");
        }
    }
}
