/****************************************************************************
* File Name: s2_reels.cs
* Author: Diana Everman
* DigiPen Email: diana.everman@digipen.edu
* Course: Video Game Programming Year 1
*
* Description: this script is used by the gamemanager for the reels phase of level 2
****************************************************************************/
using System.Collections.Generic;
using UnityEngine;

public class s2_reels : MonoBehaviour
{
    public List<GameObject> reels_list; //videoplaying objects
    private int final_index;
    private int reels_index = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        final_index = reels_list.Count - 1;
        //hide all of the reels
        for (int i = 0; i < reels_list.Count; i++)
        {
           reels_list[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //reveal the next reel and returns true if that reel was the last reel, false if not
    public bool open_reel()
    {
        //unhide the next reel
        if(reels_index <= final_index)
        {
            reels_list[reels_index].SetActive(true);
            reels_index += 1;
            return false;
        }
        //true if at the end of the reels list
        return true;
    }
}
