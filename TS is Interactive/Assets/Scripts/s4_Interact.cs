/*******************************************************************
 * File name: s4_Interact
 * Author: Diana Everman
 * Editor/Commentor: Nathen Mattis
 * Course: Video Game Programming I
 * Last edited: 1/12/2026
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
    public s4_gameManager GameManager;

    private bool changedText = false; // stored so that we aren't requesting to change the "hovering on" text every frame
    private Vector3 origin;
    private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        // Declare a variable to store information about the hit
        RaycastHit hit;

        // Origin point (e.g., the object's position) and direction (e.g., forward)
        origin = pov_camera.transform.position;
        direction = pov_camera.transform.forward;

        // Perform the raycast
        // This function returns true if an object with a transform component is hit, and populates the 'hit' variable
        if (Physics.Raycast(origin, direction, out hit, maxDistance))
        {
            // The ray hit an object! Access information via the 'hit' variable.

            // The raycast hits an object and that object is scanned for the "Interactable" tag
            if (hit.collider.gameObject.CompareTag("Interactable"))  //is an interactable object
            {
                // Tells the game manager what object the player is looking at
                if (GameManager.objectInView != hit.transform.gameObject)
                {
                    GameManager.objectInView = hit.transform.gameObject;
                }

                // Tells the game manager to update the text that displays the name of the object the player is looking at
                GameManager.objectHoverDisplay(true);
                /*if (!changedText)
                {
                    GameManager.objectHoverDisplay(true);
                    Debug.Log("hover object updated to true");

                    changedText = true;
                }*/
                //Debug.Log("YAY!!!!!");
            }
            else if (!hit.transform.gameObject.CompareTag("Interactable")) //is not an interactable object
            {

                //changedText = false; // we need to tell the game manager that something has changed
                                     // so this variable is set to false because we have new info
                                     // to provide

                GameManager.objectInView = null;
                GameManager.objectHoverDisplay(false);

                /*if (!changedText)
                {
                    GameManager.objectHoverDisplay(false);
                    Debug.Log("hover object updated to false (noninteractable)");
                    changedText = true;
                }*/
            }

        }
        else
        {
            // The ray did not hit any object within the maxDistance

            // tells the game manager there is no object in view anymore
            if (GameManager.objectInView != null)
            {
                GameManager.objectInView = null;

                GameManager.objectHoverDisplay(false);

                /*if (!changedText)
                {
                    GameManager.objectHoverDisplay(false);
                    Debug.Log("hover object updated (ray missed)");

                    changedText = true;
                }*/
                //Debug.Log("Ray missed.");
            }
        }

        Debug.DrawRay(origin, direction * maxDistance, Color.red);
    }
}
