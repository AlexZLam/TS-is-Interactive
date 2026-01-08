/*******************************************************************
 * File name: fourInteract
 * Author: Nathen Mattis
 * Digipen Email: 1119065@lwsd.org
 * Course: Video Game Programming I
 * Last edited: 1/8/2026
 *
 * Description: Prefixed with "four" to denote which scene this script
 * is for. This script is attached to the player to figure out when
 * they are able to "use AI," sending a signal to another script to
 * put the "AI's" response on the screen
 ********************************************************************/
using UnityEngine;

public class fourInteract : MonoBehaviour
{
    public bool canInteract;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("interact");
        }*/
        //Debug.Log("enter triggered");

    }

    private void processInputs()
    {

    }
}
