/****************************************************************************
* File Name: pooperAnim
* Author: Alexander Lam
* DigiPen Email: alexander.lam@digipen.edu
* Course: Video Game Programming Year 1
*
* Description: Controls the animation for the Pooper Man NPC
****************************************************************************/
using UnityEngine;

public class pooperAnim : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetBool("Lebron", true);
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Lebron", false);
        }
            
    }

}
