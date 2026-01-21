/*
 * File Name: s6_playCrash.cs
 * Author: Jackson LeClaire
 * DigiPen Email: jackson.leclaire@digipen.edu
 * Course: WANIC Computer Programming Year 1
 * 
 * Description: Plays a crash audio and pans it according to where the "car" is
 */
using UnityEngine;

public class s6_playCrash : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip clip;
    public float pan = 1;
    private bool can = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Observes when a player enters the trigger area
            can = true;
            audio.PlayOneShot(clip);
        }
    }

    private void Update()
    {
        if (can == true)
        {
            audio.panStereo = pan - Time.deltaTime;
        }
    }

}
