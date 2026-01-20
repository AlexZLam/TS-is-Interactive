using UnityEngine;

public class s6_car : MonoBehaviour
{
    public GameObject car;
    public Animator animator;
    public Rigidbody rb;
    public CharacterController cc;
    private bool hitr;
    public Camera mCam;
    public float timer;
    public GameObject black;
    public AudioSource smash;
    public AudioClip clip;
    public Music music;

    private void Start()
    {
        black.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Crash", true);
            Vector3 direction = Vector3.up;
            Vector3 left = Vector3.right;
            rb.constraints = RigidbodyConstraints.None;
            cc.enabled = false;
            smash.PlayOneShot(clip);
            music.AudioSource.mute = true;
            rb.AddForce(direction * 10, ForceMode.Impulse);
            rb.AddForce(left * 50, ForceMode.Impulse);
            hitr = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            animator.SetBool("Crash", false);
    }

    private void Update()
    {
        if (hitr == true)
        {
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                black.SetActive(true);
            }
        }
    }
}
