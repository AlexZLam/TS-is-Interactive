/*******************************************************************
 * File name: s4_Interact
 * Author: Diana Everman
 * Editor/Commentor: Nathen Mattis
 * Digipen Email: 1119065@lwsd.org
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


            // The raycast hits an object and that object is scanned for the "Interactable" tag
            if (hit.collider.gameObject.CompareTag("Interactable"))
            {
                if (GameManager.objectInView != hit.collider.gameObject)
                {
                    GameManager.objectInView = hit.collider.gameObject;
                }

                GameManager.objectHoverDisplay();
                //Debug.Log("YAY!!!!!");
            }
            /*else if (!hit.collider.gameObject.CompareTag("Interactable"))
            {
                GameManager.objectInView = null;
            }*/

        }
        else
        {
            // The ray did not hit any object within the maxDistance

            //update gameManager obj_in_view if needed
            /*if (gameManager.obj_in_view != null)
            {
                gameManager.obj_in_view = null;
                Debug.Log("Ray missed.");
            }*/
        }

        Debug.DrawRay(origin, direction * maxDistance, Color.red);
    }

    private void processHit()
    {

    }
}
