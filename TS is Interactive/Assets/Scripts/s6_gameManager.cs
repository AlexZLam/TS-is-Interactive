/*
 * File Name: s6_gameManager.cs
 * Author: Diana Everman, Jackson LeClaire
 * DigiPen Email: diana.everman@digipen.edu, jackson.leclaire@digipen.edu
 * Course: WANIC Computer Programming Year 1
 * 
 * Description: A game manager, functions include detecting different types of objects
 *              in the player's view and displaying text for a time
 */
using UnityEngine;

public class s6_GameManager : MonoBehaviour
{
    public GameObject text_display_obj;
    public bool level_done = false;
    public GameObject obj_in_view;
    private TMPro.TextMeshProUGUI text_display;
    public GameObject fullDoor;
    public bool textShowing;
    public GameObject canvasReference;
    public Music Music;
    public GameObject player;
    public AudioSource pickup;
    public AudioClip cs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Confirms that the text display object is active and checks to confirm that there is a 
        // TextMeshProUGUI
        text_display_obj.SetActive(true);
        text_display = text_display_obj.GetComponent<TMPro.TextMeshProUGUI>();
        if (text_display == null)
        {
            Debug.Log("text_display_obj has no TMPro.TextMeshProUGUI component.");
        }
        level_done = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (level_done == false)
        {
            //if left mouse button clicked
            if (Input.GetMouseButtonDown(0))
            {
                if (obj_in_view != null)
                {
                    if (obj_in_view.GetComponent<s2_clickable_object>() != null)
                    { 
                        string obj_flavortext = obj_in_view.GetComponent<s2_clickable_object>().flavortext;
                        if (obj_flavortext != "")
                        {
                            displayText(obj_flavortext);
                        }
                        string obj_phase = obj_in_view.GetComponent<s2_clickable_object>().phase;
                        if (obj_phase != "")
                        {
                            if (obj_phase == "door")
                            {
                                if (Music.glasses == true)
                                {
                                    obj_in_view.GetComponent<Animation>().Play();
                                }
                            }
                            else if (obj_phase == "meta")
                            {
                                obj_in_view.transform.position = new Vector3(100, -100f, 100);
                                pickup.PlayOneShot(cs);
                                Music.glasses = true;
                            }
                            else if (obj_phase == "man")
                            {
                                player.transform.position = new Vector3(0, 18.18f, 0);
                            }
                        }
                    }
                }
            }
        }
    }
    // Instantiates a text object to show and delete
    void displayText(string text)
    {
        text_display.text = text;
        GameObject textObject = Instantiate(text_display_obj);
        textObject.transform.SetParent(canvasReference.transform, false);
    }


}


