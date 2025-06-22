using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float stoppingDistance = 1f;
    [SerializeField] private float rotationSpeed = 5f;

    [Header("Detection Settings")]
    [SerializeField] private float detectionRadius = 5f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask obstacleLayer;

    private Transform player;
    private Rigidbody2D rb;
    private bool isChasing = false;
    private Vector2 lastKnownPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            isChasing = true;
            lastKnownPosition = player.position;
        }
        else if (isChasing)
        {
            if (Vector2.Distance(transform.position, lastKnownPosition) < 0.5f)
            {
                isChasing = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
    }

    bool CanSeePlayer()
    {
        Collider2D playerInRange = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);

        if (playerInRange != null)
        {
            Vector2 directionToPlayer = (player.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, detectionRadius, obstacleLayer);

            if (hit.collider == null || hit.collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    void ChasePlayer()
    {
        Vector2 direction = (lastKnownPosition - (Vector2)transform.position).normalized;
        float distance = Vector2.Distance(transform.position, lastKnownPosition);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = Mathf.LerpAngle(rb.rotation, angle, rotationSpeed * Time.fixedDeltaTime);

        if (distance > stoppingDistance)
        {
            rb.linearVelocity = direction * moveSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        if (isChasing)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, lastKnownPosition);
        }
    }
}