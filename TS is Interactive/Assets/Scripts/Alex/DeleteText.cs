/****************************************************************************
* File Name: DeleteText
* Author: Alexander Lam
* DigiPen Email: alexander.lam@digipen.edu
* Course: Video Game Programming Year 1
*
* Description: Destroys text at the beginning of the scene
****************************************************************************/
using UnityEngine;

public class DeleteText : MonoBehaviour
{
    public GameObject text;

    //When a player touches the trigger, delete the text
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Destroy(text);
    }
}
