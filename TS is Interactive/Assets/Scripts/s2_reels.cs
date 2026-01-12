using System.Collections.Generic;
using UnityEngine;

public class s2_reels : MonoBehaviour
{
    public List<GameObject> reels_list;
    private int final_index;
    private int reels_index = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        final_index = reels_list.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool open_reel()
    {
        reels_list[reels_index].SetActive(true);
        reels_index += 1;
        //open reel, returns true if done w all reels
        if(final_index == reels_index)
        {
            return true;
        }
        return false;
    }
}
