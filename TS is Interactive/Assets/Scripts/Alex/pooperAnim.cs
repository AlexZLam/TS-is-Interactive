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
