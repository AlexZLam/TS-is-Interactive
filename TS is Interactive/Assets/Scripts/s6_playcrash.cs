using UnityEngine;

public class s6_playcrash : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip clip;
    public float pan = -1;
    private bool can = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            can = true;
            audio.PlayOneShot(clip);
        }
    }

    private void Update()
    {
        if (can == true)
        {
            audio.panStereo = pan + Time.deltaTime;
        }
    }

}
