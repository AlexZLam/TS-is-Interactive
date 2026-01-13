using UnityEngine;
using UnityEngine.UI;


public class stealjersey : MonoBehaviour
{
    bool canPress = false;
    public GameObject jersey;
    public GameObject text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPress = true;
            text.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPress = false;
            text.SetActive(false);
        }
    }
    void Update()
    {
        if(canPress)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(jersey);
            }
            
        }
    }
}
