/*******************************************************************
 * File name: s4_Interact
 * Author: Diana Everman
 * Editor/Commentor: Nathen Mattis
 * Digipen Email: 1119065@lwsd.org
 * Course: Video Game Programming I
 * Last edited: 1/9/2026
 *
 * Description: Prefixed with "s4" to denote which scene this script
 * is for. This script is attached to the player to figure out when
 * they are able to "use AI," sending a signal to another script to
 * put the "AI's" response on the screen. When the mouse is hovering
 * over an interactable object (with the tag "Interactable"), they
 * will be able to generate an AI prompt related to the object they
 * are hovering over (which, in this case, would be looking at, since
 * the mouse is constantly in the middle of the screen. hopefully)
 ********************************************************************/
using UnityEngine;
using UnityEngine.EventSystems;

public class fourInteract : MonoBehaviour
{
    public float maxDistance = 3f;
    public Camera pov_camera;
    public s2_GameManager gameManager;
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

            //update gameManager obj_in_view if needed
            if (gameManager.obj_in_view != hit.transform.gameObject)
            {
                gameManager.obj_in_view = hit.transform.gameObject;
                Debug.Log("Hit object: " + hit.transform.name);
                Debug.Log("Hit point: " + hit.point); // The exact world position of the hit
            }
        }
        else
        {
            // The ray did not hit any object within the maxDistance

            //update gameManager obj_in_view if needed
            if (gameManager.obj_in_view != null)
            {
                gameManager.obj_in_view = null;
                Debug.Log("Ray missed.");
            }
        }

        Debug.DrawRay(origin, direction * maxDistance, Color.red);

        /*
         plan:
        - give the gamemanager the current obj im looking at
        - only change it if the obj im looking at just changed
         */
    }
}
