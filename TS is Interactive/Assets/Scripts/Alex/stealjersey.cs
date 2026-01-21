/****************************************************************************
* File Name: stealJersey
* Author: Alexander Lam
* DigiPen Email: alexander.lam@digipen.edu
* Course: Video Game Programming Year 1
*
* Description: Lets player interact and steal the jersey to end scene
****************************************************************************/
using UnityEngine;
using UnityEngine.UI;


public class stealjersey : MonoBehaviour
{
    bool canPress = false;
    public GameObject jersey;
    public GameObject text;
    public SceneSwitcher sceneS;
    //sets sceneS to the sceneSwitcher
    void Start()
    {
        sceneS = GameObject.FindGameObjectWithTag("SceneSwitcher").GetComponent<SceneSwitcher>();
    }

    //When the player enters the trigger box, display the "Press E Text"
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPress = true;
            text.SetActive(true);
        }
    }
    //Disables "Press E" text when the player leaves the trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPress = false;
            text.SetActive(false);
        }
    }

    //If the the player is in the trigger box and they press E, destroy the Jersey and switch the scenes
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
