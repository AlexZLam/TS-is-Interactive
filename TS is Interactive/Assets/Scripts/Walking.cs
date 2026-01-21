/****************************************************************************
* File Name: Walkiing
* Author: Alexander Lam
* DigiPen Email: alexander.lam@digipen.edu
* Course: Video Game Programming Year 1
*
* Description: Plays footstep noises that are synched with the player controller
****************************************************************************/
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip walkClip;
    public AudioClip runClip;
    public AudioClip crouchClip;

    public float walkInterval = 0.5f;
    public float runInterval = 0.35f;
    public float crouchInterval = 0.8f;

    private float stepTimer;

    // References to your movement script
    public BasicFPCC movement;


        /****************************************************************************
    * Function: Update
    *
    * Description: Chekcs if the footsteps can be played. If the player is not doing any action besides walking, it will play footsteps every half second
    *
    ****************************************************************************/
    void Update()
    {
        if (movement == null) return;

        bool isMoving = movement.inputMoveX != 0 || movement.inputMoveY != 0;
        bool grounded = movement.isGrounded;
        bool sliding = movement.isSliding;

        if (!grounded || sliding || !isMoving)
        {
            stepTimer = 0f;
            return;
        }

        float currSpeed = movement.lastSpeed;

        AudioClip clipToPlay;
        float interval;

        // Choose sound + interval based on movement state
        if (movement.inputKeyCrouch)
        {
            clipToPlay = crouchClip;
            interval = crouchInterval;
        }
        else if (movement.inputKeyRun)
        {
            clipToPlay = runClip;
            interval = runInterval;
        }
        else
        {
            clipToPlay = walkClip;
            interval = walkInterval;
        }

        stepTimer -= Time.deltaTime;

        if (stepTimer <= 0f)
        {
            audioSource.PlayOneShot(clipToPlay);
            stepTimer = interval;
        }
    }
}
