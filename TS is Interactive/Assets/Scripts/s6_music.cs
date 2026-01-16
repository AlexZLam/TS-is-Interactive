using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public GameObject spotify;
    public bool glasses = false;
    public Animator flyIn;
    public int songSelect = 0;
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
        overlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        if (glasses == true)
        {
            flyIn.SetBool("animate", true);
            musicController();
            overlay.SetActive(true);
        }
    }

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
