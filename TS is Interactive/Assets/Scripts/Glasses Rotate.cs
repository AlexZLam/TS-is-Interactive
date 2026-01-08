using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    void Update()
    {
        // Rotate the object around its local y axis at 1 degree per second
        transform.Rotate((Vector3.up * 50) * Time.deltaTime);
    }
}