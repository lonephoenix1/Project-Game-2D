using UnityEngine;

public class EnemyWolfMovement : MonoBehaviour
{
    public Transform targetCharacter; // Referencja do postaci, za któr¹ pod¹¿amy
    public float moveSpeed = 3.0f;
    public float detectionRadius = 5.0f; // Promieñ detekcji postaci
    private SpriteRenderer rbSprite;
    private Animator animator;
    private Rigidbody2D rb;
    Vector2 movement;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rbSprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (targetCharacter != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, targetCharacter.position);

            // Sprawdzamy, czy postaæ jest w zasiêgu
            if (distanceToTarget <= detectionRadius)
            {
                // Obliczamy kierunek ruchu
                Vector3 targetPosition = targetCharacter.position;
                Vector3 moveDirection = (targetPosition - transform.position).normalized;

                // Ruch w kierunku postaci
                transform.position += moveDirection * moveSpeed * Time.deltaTime;
            }
        }

        if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            rb.velocity = Vector3.zero;
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            rbSprite.flipX = true;
        }
        else
        {
            rbSprite.flipX = false;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

    }
}
