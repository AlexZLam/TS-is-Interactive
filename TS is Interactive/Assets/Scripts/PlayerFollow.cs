using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;
    public Animator animator;

    private bool shouldLookAtPlayer = false;
    private bool hasPlayedAnimation = false;

    public void StartRotationAnimation()
    {
        if (hasPlayedAnimation) return;

        hasPlayedAnimation = true;
        animator.SetTrigger("Rotate");

        // Change this to match your animation length
        Invoke(nameof(StartLooking), 3f);
    }

    void StartLooking()
    {
        shouldLookAtPlayer = true;
    }

    void Update()
    {

        if (!shouldLookAtPlayer) return;

        Vector3 target = player.position;
        Debug.Log("Player Postition " + target);
        target.y = transform.position.y;
        transform.LookAt(target);
    }
}
