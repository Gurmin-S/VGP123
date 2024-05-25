using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    public bool TestMode;


    [SerializeField] private int speed;
    [SerializeField] private int jumpForce = 3;

    // GroundCheck
    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask isGroundLayer;
    [SerializeField] private float groundCheckRadius;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (speed <= 0)
        {
            speed = 5;
            if (TestMode) Debug.Log("Speed set to Default value");
        }

        if (jumpForce <= 0)
        {
            jumpForce = 3;
            if (TestMode) Debug.Log("JumpForce set to Default value");
        }

        if (groundCheck == null)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("GroundCheck");

            if (obj != null)
            {
                groundCheck = obj.transform;
            }
            else
            {
                GameObject newObj = new GameObject();
                newObj.transform.SetParent(transform);
                newObj.transform.localPosition = Vector3.zero;
                newObj.name = "GroundCheck";
                newObj.tag = newObj.name;
                groundCheck = newObj.transform;
                if (TestMode) Debug.Log("Ground check Transform Created via code - Did you forget to assign it in the inspector?");
            }
        }
    }

    void Update()
    {

        float xInput = Input.GetAxis("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);
        Vector2 moveDirection = new Vector2(xInput * speed, rb.velocity.y);
        rb.velocity = moveDirection;

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Attack");
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (xInput != 0) sr.flipX = (xInput < 0);

        anim.SetFloat("speed", Mathf.Abs(xInput));
        anim.SetBool("isGrounded", isGrounded);
    }
}
