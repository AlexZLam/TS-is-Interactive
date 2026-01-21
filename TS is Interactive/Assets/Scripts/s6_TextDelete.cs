/*
 * File Name: s6_TextDelete.cs
 * Author: Jackson LeClaire
 * DigiPen Email: jackson.leclaire@digipen.edu
 * Course: WANIC Computer Programming Year 1
 * 
 * Description: Literally just deletes text after a set period of time
 */
using UnityEngine;

public class s6_TextDelete : MonoBehaviour
{
    private float timer = 0;
    private s6_GameManager manager;


    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                Destroy(gameObject);
            }
    }
}
