/*******************************************************************
 * File name: s4_Interact
 * Author: Nathen Mattis
 * Digipen Email: 1119065@lwsd.org
 * Course: Video Game Programming I
 * Last edited: 1/8/2026
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

public class s4_Interact : MonoBehaviour
{
    public Material highlightMaterial;
    public Material selectionMaterial;

    private Material originalMaterial;
    private Transform highlight; // internal, only the computer will realize what is highlighted and what is
                                 // not because I'm probably not going to learn how to give an object an outline
    private Transform selection;
    private RaycastHit raycastHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (highlight != null)
        {
            //highlight.GetComponent<MeshRenderer>().material = originalMaterial;
            highlight = null;
        }
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            highlight = raycastHit.transform;
            hoveringProcess();
        }


        interactionProcess();
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("interact");
        }*/

        //Debug.Log("enter triggered");

    }

    private void hoveringProcess()
    {
        if (highlight.CompareTag("Interactable") && highlight != selection)
        {
            //Debug.Log("Hovering over interactable object");
        }
        else
        {
            highlight = null;
        }
    }

    private void interactionProcess()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKey(KeyCode.E) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (selection != null)
            {
                //selection.GetComponent<MeshRenderer>().material = originalMaterial;
                selection = null;
            }

            if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
            {
                selection = raycastHit.transform;
                if (selection.CompareTag("Interactable"))
                {
                    processInput();
                }
                else
                {
                    selection = null;
                }
            }
        }
    }

    private void processInput()
    {
        Debug.Log("Attempt to interact successful");
    }
}
