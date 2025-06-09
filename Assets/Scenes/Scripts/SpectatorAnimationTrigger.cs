using UnityEngine;

public class SpectatorAnimationTrigger : MonoBehaviour
{
    public Animator animator;
    public string playerTag = "Player";
    public float triggerDistance = 5f;
    private bool hasPlayedExcited = false;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag)?.transform;
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < triggerDistance && !hasPlayedExcited)
        {
            animator.SetTrigger("PlayerNearby");
            hasPlayedExcited = true;
        }
        else if (distance >= triggerDistance && hasPlayedExcited)
        {
            // Optional: Reset to idle if player leaves
            hasPlayedExcited = false;
            // Optionally use a second trigger or a Bool to return to Idle
        }
    }
}
