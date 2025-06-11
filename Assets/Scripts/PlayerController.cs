using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed;
    public Vector3 PlayerMoveDirection;
    public float playerMaxVida;
    public float playerVida;

    private bool imune;
    [SerializeField] private float imuneDuration;
    [SerializeField] private float imuneTimer;

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

    private void Start()
    {
        playerVida = playerMaxVida;
        UIController.Instance.UpdateHealthSlider(); 
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
        if(imuneTimer > 0)
        {
            imuneTimer -= Time.deltaTime;
        }
        else
        {
            imune = false;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(PlayerMoveDirection.x *
            moveSpeed, PlayerMoveDirection.y * moveSpeed);
    }

    public void TakeDamage(float damage)
    {
        if (!imune)
        {
            imune = true;
            imuneTimer = imuneDuration;
            playerVida -= damage;
            UIController.Instance.UpdateHealthSlider();
            if (playerVida <= 0)
            {
                gameObject.SetActive(false);
                GameManager.Instance.GameOver();
            }
        }
        
    }
}
