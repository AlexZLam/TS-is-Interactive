/****************************************************************************
* File Name: cartianim
* Author: Alexander Lam
* DigiPen Email: alexander.lam@digipen.edu
* Course: Video Game Programming Year 1
*
* Description: Controls the animation for the Carti Man NPC
****************************************************************************/
using UnityEngine;

public class cartianim : MonoBehaviour
{
    public Animator animator;

    //Starts the Carti animation
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("carti", true);

        }
    }
    //stops the Carti animation
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("carti", false);
        }

    }

}
