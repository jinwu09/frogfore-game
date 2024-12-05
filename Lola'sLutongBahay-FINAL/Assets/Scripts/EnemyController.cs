using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public float moveSpeed = 2.0f; // Enemy movement speed
    public float stoppingDistance = 1.0f; // Distance at which the enemy stops chasing
    public float detectionDistance = 5.0f; // Detection range for the player

    public UnityEvent onCollisionWithPlayer; // Unity Event to invoke on collision with the player

    private Rigidbody2D rb;
    private bool isChasing = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (target == null)
            return;

        // Calculate the distance to the player
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        if (isChasing)
        {
            // If already chasing and the player is too far, stop chasing
            if (distanceToPlayer > detectionDistance)
            {
                isChasing = false;
                rb.velocity = Vector2.zero;
            }
            else
            {
                // Continue chasing the player
                ChasePlayer();
            }
        }
        else
        {
            // If not currently chasing and the player is within detection range, start chasing
            if (distanceToPlayer <= detectionDistance)
            {
                isChasing = true;
                ChasePlayer();
            }
        }

        // Check if the enemy is close enough to stop chasing
        if (isChasing && distanceToPlayer <= stoppingDistance)
        {
            // Invoke the Unity Event when colliding with the player
            onCollisionWithPlayer.Invoke();
        }
    }

    private void ChasePlayer()
    {
        // Calculate the direction to the player
        Vector2 direction = (target.position - transform.position).normalized;

        // Move towards the player
        rb.velocity = direction * moveSpeed;
    }

    // OnCollisionEnter2D is called when the enemy's collider collides with the player's collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Invoke the Unity Event when colliding with the player
            onCollisionWithPlayer.Invoke();
        }
    }
}
