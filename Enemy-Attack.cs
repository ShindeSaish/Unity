using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float detectionRange = 10f;
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;

    private Transform player;
    private NavMeshAgent agent;
    private Animator animator;
    private float lastAttackTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            agent.SetDestination(player.position);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (distance <= attackRange)
        {
            agent.SetDestination(transform.position);
            animator.SetBool("isRunning", false);

            if (Time.time >= lastAttackTime + attackCooldown)
            {
                animator.SetTrigger("Attack"); // <-- animation trigger
                lastAttackTime = Time.time;
            }
        }
    }

    // This will be called from animation event
    public void DealDamage()
    {
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(10);
        }
    }
}
