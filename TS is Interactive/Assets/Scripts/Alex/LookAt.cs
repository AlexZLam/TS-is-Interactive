/****************************************************************************
* File Name: LookAt
* Author: Alexander Lam
* DigiPen Email: alexander.lam@digipen.edu
* Course: Video Game Programming Year 1
*
* Description:Plays an animation on the Couch NPC
****************************************************************************/
using UnityEngine;

public class TriggerLookAt : MonoBehaviour
{
    public LookAtPlayer targetObject;

    //When the player steps into the trigger, play the animation
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetObject.StartRotationAnimation();
        }
    }
}
