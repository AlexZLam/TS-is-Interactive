/****************************************************************************
* File Name: StarWarsCredits
* Author: Alexander Lam
* DigiPen Email: alexander.lam@digipen.edu
* Course: Video Game Programming Year 1
*
* Description: Plays the credits that explain the interactive experience with Star Wars opening  esque text
****************************************************************************/
using UnityEngine;

public class StarWarsCredits : MonoBehaviour
{
    public float scrollSpeed = 1f;
    public float backSpeed = 1f;
    
    //Moves the text across the screen
    void Update()
    {
        // Move up
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime, Space.World);
        //Move Back
        transform.Translate(Vector3.forward * backSpeed * Time.deltaTime, Space.World);
    }
}
