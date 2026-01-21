/*
 * File Name: s6_music.cs
 * Author: Jackson LeClaire
 * DigiPen Email: jackson.leclaire@digipen.edu
 * Course: WANIC Computer Programming Year 1
 * 
 * Description: Activates a shell "Spotify" to play music to the player
 */
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public GameObject spotify;
    public bool glasses = false;
    public Animator flyIn;
    public int songSelect;
    public AudioSource AudioSource;
    public AudioClip tank;
    public AudioClip popOut;
    public AudioClip tester;
    public AudioClip life;
    public AudioClip rap;
    public Texture2D carti1;
    public Texture2D carti2;
    public Texture2D jpeg;
    public Texture2D danny;
    public Texture2D yuno;
    public float cooldown = 0;
    public GameObject overlay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Confirms that the Spotify overlay is not active
        overlay.SetActive(false);
        //Shuffles the songs
        songSelect = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        // Plays an animation and starts the music
        if (glasses == true)
        {
            flyIn.SetBool("animate", true);
            musicController();
            overlay.SetActive(true);
        }
    }
    // Controls the music playing at any given time
    private void musicController()
    {
        if (AudioSource.isPlaying == false)
        {
            if (songSelect == 0)
            {
                AudioSource.PlayOneShot(tank);
                spotify.GetComponent<RawImage>().texture = carti1;
                ++songSelect;
            }
            else if (songSelect == 1)
            {
                AudioSource.PlayOneShot(popOut);
                spotify.GetComponent<RawImage>().texture = carti2;
                ++songSelect;
            }
            else if (songSelect == 2)
            {
                AudioSource.PlayOneShot(tester);
                spotify.GetComponent<RawImage>().texture = jpeg;
                ++songSelect;
            }
            else if (songSelect == 3)
            {
                AudioSource.PlayOneShot(life);
                spotify.GetComponent<RawImage>().texture = danny;
                ++songSelect;
            }
            else if (songSelect == 4)
            {
                AudioSource.PlayOneShot(rap);
                spotify.GetComponent<RawImage>().texture = yuno;
                ++songSelect;
            }
            else
            {
                songSelect = 0;
            }
        }
        else
        {
            if (cooldown > 2f)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    AudioSource.Stop();
                    cooldown = 0;
                }
            }

        }
    }
}
