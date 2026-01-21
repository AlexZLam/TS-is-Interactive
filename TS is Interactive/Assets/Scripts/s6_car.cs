/*
 * File Name: s6_car.cs
 * Author: Jackson LeClaire
 * DigiPen Email: jackson.leclaire@digipen.edu
 * Course: WANIC Computer Programming Year 1
 * 
 * Description: Detects a player in a trigger, then causes them to be hit by a car
 */
using UnityEngine;

public class s6_car : MonoBehaviour
{
    public GameObject car;
    public Animator animator;
    public Rigidbody rb;
    public CharacterController cc;
    private bool hitr;
    public Camera mCam;
    public float timer;
    public GameObject black;
    public AudioSource smash;
    public AudioClip clip;
    public Music music;


    private void Start()
    {
        //Makes a black screen entity not show up while the player is actually playing the game
        black.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Crash", true);
            //Makes the player take some force to imitate being hit by a car
            Vector3 direction = Vector3.up;
            Vector3 left = Vector3.right;
            rb.constraints = RigidbodyConstraints.None;
            cc.enabled = false;
            smash.PlayOneShot(clip);
            music.AudioSource.mute = true;
            rb.AddForce(direction * 10, ForceMode.Impulse);
            rb.AddForce(left * 50, ForceMode.Impulse);
            hitr = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        // Resets the car if the player leaves the trigger area
        if (other.CompareTag("Player"))
            animator.SetBool("Crash", false);
    }

    private void Update()
    {
        if (hitr == true)
        {
            // After an amount of time, make the screen blackout
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                black.SetActive(true);
            }
        }
    }
}
