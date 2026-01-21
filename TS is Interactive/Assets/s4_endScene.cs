/*******************************************************************
 * File name: s4_endScene
 * Author: Nathen Mattis
 * Email: 1119065@lwsd.org
 * Course: Video Game Programming I
 * Last edited: 1/21/2026
 *
 * Description: Attached to the object which triggers our scene 
 * switcher to switch scenes when collided with.
 ********************************************************************/
using UnityEngine;

public class s4_endScene : MonoBehaviour
{
    public SceneSwitcher sceneS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneS = GameObject.FindGameObjectWithTag("SceneSwitcher").GetComponent<SceneSwitcher>();
    }

    private void OnTriggerEnter(Collider other)
    {
        sceneS.switchScene = true;
        Debug.Log("level ended");
    }
}
