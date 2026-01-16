using UnityEngine;

public class s5_switch_on_collision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        FindAnyObjectByType<SceneSwitcher>().switchScene = true;
    }
    
}
