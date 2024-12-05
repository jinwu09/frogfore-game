using UnityEngine;
using UnityEngine.AI;

public class PetController : MonoBehaviour
{
    public Transform player; // Player's transform
    public float followDistance = 2.0f; // The distance at which the pet will stop following the player

    [SerializeField] float moveSpeed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (player == null)
        {
            Debug.LogError("Player transform not assigned to PetController!");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            Vector2 petPosition = rb.position;
            Vector2 playerPosition = player.position;

            float distanceToPlayer = Vector2.Distance(petPosition, playerPosition);

            if (distanceToPlayer > followDistance)
            {
                // Move the pet towards the player
                Vector2 moveDirection = (playerPosition - petPosition).normalized;
                rb.velocity = moveDirection * moveSpeed;
            }
            else
            {
                // Stop when close to the player
                rb.velocity = Vector2.zero;
            }
        }
    }
}
