using UnityEngine;
using UnityEngine.UI;


public class stealjersey : MonoBehaviour
{
    bool canPress = false;
    public GameObject jersey;
    public GameObject text;
    public SceneSwitcher sceneS;
    void Start()
    {
        sceneS = GameObject.FindGameObjectWithTag("SceneSwitcher").GetComponent<SceneSwitcher>();
    }

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
                sceneS.switchScene = true;
            }
            
        }
    }
}
