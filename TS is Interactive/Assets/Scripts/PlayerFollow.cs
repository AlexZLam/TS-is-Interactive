using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;
    public Animator lilAnimator;
    public Animator canvasAnimator;

    private bool shouldLookAtPlayer = false;
    private bool hasPlayedAnimation = false;
    private bool finishPopUps = false;

    public void StartRotationAnimation()
    {
        if (hasPlayedAnimation) return;

        hasPlayedAnimation = true;
        lilAnimator.SetTrigger("Rotate");

        Invoke(nameof(StartLooking), 3f);
        canvasAnim();
    }

    void StartLooking()
    {
        shouldLookAtPlayer = true;
    }

    void Update()
    {
        if (!shouldLookAtPlayer) return;
        followPlayer();
    }

    void followPlayer()
    {
        Vector3 target = player.position;
        target.y = transform.position.y;
        transform.LookAt(target);
    }

    public void canvasAnim()
    {
        if (finishPopUps) return;

        finishPopUps = true;

        // Play ONE animation clip
        canvasAnimator.SetTrigger("Playonce");
    }
}
