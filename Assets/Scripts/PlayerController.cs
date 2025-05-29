using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed;
    public Vector3 PlayerMoveDirection;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        PlayerMoveDirection = new Vector2(inputX, inputY).normalized;

        animator.SetFloat("moveX", inputX);
        animator.SetFloat("moveY", inputY);

        if (PlayerMoveDirection == Vector3.zero)
        {
            animator.SetBool("moving", false);
        }
        else {
            animator.SetBool("moving", true);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(PlayerMoveDirection.x *
            moveSpeed, PlayerMoveDirection.y * moveSpeed);
    }
}
