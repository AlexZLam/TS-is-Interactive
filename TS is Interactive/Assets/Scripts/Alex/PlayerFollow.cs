/****************************************************************************
* File Name: PlayerFollow
* Author: Alexander Lam
* DigiPen Email: alexander.lam@digipen.edu
* Course: Video Game Programming Year 1
*
* Description: Rotates the Couch NPC towards the player
****************************************************************************/
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;
    public Animator lilAnimator;
    public Animator canvasAnimator;

    private bool shouldLookAtPlayer = false;
    private bool hasPlayedAnimation = false;
    private bool finishPopUps = false;

    //Starts animation to rotate and then plays the canvas animation after 3 seconds
    public void StartRotationAnimation()
    {
        if (hasPlayedAnimation) return;

        hasPlayedAnimation = true;
        lilAnimator.SetTrigger("Rotate");

        Invoke(nameof(StartLooking), 3f);
        canvasAnim();
    }

    //sets bool to look at player
    void StartLooking()
    {
        shouldLookAtPlayer = true;
    }
    //if not already looking at the player, start looking at them
    void Update()
    {
        if (!shouldLookAtPlayer) return;
        followPlayer();
    }
    
    //Get the players position on the Y axis and rotates the Couch NPC towards it
    void followPlayer()
    {
        Vector3 target = player.position;
        target.y = transform.position.y;
        transform.LookAt(target);
    }

    //plays the canvas animation
    public void canvasAnim()
    {
        if (finishPopUps) return;

        finishPopUps = true;

        // Play ONE animation clip
        canvasAnimator.SetTrigger("Playonce");
    }
}
