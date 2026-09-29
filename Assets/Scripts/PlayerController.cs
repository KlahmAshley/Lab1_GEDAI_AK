using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public float speed = 8f;
    private bool isFacingRight = true;

    private BubbleControls bc; //TUTORIAL PROGRAMMING 3
    private PlayerInput playerInput;
    

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public float layermask = 1;

    public float maxPower = 1f;
    public float powerForce = 0.5f;
    public Transform grounded;
    [SerializeField] ParticleSystem bubbleEffect;
    private float currentPower;
    public GameObject helpMenu;

    public Animator animator;

    public TMP_Text EBCounter;
    public int remainingEB = 30;
    public int collected = 0;

    public GameObject endScene;

    public AudioSource collect;
    public AudioSource backgroundMusic;
    public AudioSource ground;

    public GameObject spawnPoint;

    void Start()
    {
        Debug.Log("Check");
        currentPower = maxPower;
        bubbleEffect.gameObject.SetActive(false);
        EBCounter.text = collected +"/"+ remainingEB;
    }

    private void Awake()
    {
        bc = new BubbleControls();

        InitInputActions(); //TUTORIAL PROGRAMMING 3
        playerInput = GetComponent<PlayerInput>();
        
    }

    private void OnEnable() //TUTORIAL PROGRAMMING 3
    {
        bc.Enable();
    }

    private void OnDisable() //TUTORIAL PROGRAMMING 3
    {
        bc.Disable();
    }

    void Update()
    {

          horizontal = Input.GetAxisRaw("Horizontal");
          vertical = Input.GetAxisRaw("Vertical"); 

        /* if (Input.GetKeyDown(KeyCode.H) && helpMenu.activeSelf)
        {
             helpMenu.gameObject.SetActive(true);
        }*/

        Flip();

        Debug.Log(SceneManager.GetActiveScene().name);

      if (remainingEB == collected && SceneManager.GetActiveScene().name == ("SampleScene"))
        {
            SceneManager.LoadScene("Level2");
            Debug.Log("HELLO???");
       
        }
      else if (remainingEB == collected && SceneManager.GetActiveScene().name == ("Level2"))
        {
            SceneManager.LoadScene("Level3");

        }
      else if (remainingEB == collected && SceneManager.GetActiveScene().name == ("Level3"))
        {
            endScene.SetActive(true);

        }



    }

    private void InitInputActions()//TUTORIAL PROGRAMMING 3
    {
        bc.BFM_Default.Movement.performed += ctx => MovePlayer(ctx.ReadValue<Vector2>());
        bc.BFM_Default.Movement.canceled += ctx => MovePlayer(new Vector2());

    }

    private void MovePlayer(Vector2 movementDir)//TUTORIAL PROGRAMMING 3
    {
        rb.velocity = movementDir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            animator.SetBool("IsFalling", false);
            animator.SetBool("IsFloating", false);
            ground.Play();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (horizontal != 0f)
        {
            animator.SetBool("IsWalking", true);
        }

        if (horizontal == 0f)
        {
            animator.SetBool("IsWalking", false);
        }

        if (vertical == 0f)
        {
            animator.SetBool("IsFalling", false);
            animator.SetBool("IsFloating", false);
        }


        if (Input.GetAxisRaw("Jump") < 0f && !IsGrounded())
        {
            animator.SetBool("IsFloating", true);
        }

        if (Input.GetAxisRaw("Jump") > 0f && currentPower > 0f)
        {
            currentPower -= Time.deltaTime;
            rb.AddForce(rb.transform.up * powerForce, ForceMode2D.Impulse);
            bubbleEffect.gameObject.SetActive(true);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsFalling", false);
            animator.SetBool("IsFloating", true);
        }
        else if (Physics.Raycast(grounded.position, Vector2.down, 1f, LayerMask.GetMask("Ground")) && currentPower < maxPower || currentPower == 0.0f)
        {
            currentPower += Time.deltaTime;
            bubbleEffect.gameObject.SetActive(false);
            animator.SetBool("IsFloating", false);
            animator.SetBool("IsFalling", true);
            animator.SetBool("IsWalking", false);

        }
        else
        {
            bubbleEffect.gameObject.SetActive(false);
            animator.SetBool("ISWalking", false);
            animator.SetBool("IsFloating", false);
            animator.SetBool("IsFalling", true);
        }

        if (IsGrounded())
        {
            animator.SetBool("IsFloating", false);
            animator.SetBool("IsFalling", false);
            bubbleEffect.gameObject.SetActive(false);

            if (currentPower < maxPower)
            {
                currentPower += Time.deltaTime;
            }
        }

    }





    private void OnCollisionEnter(Collision collision)
    {
       if( collision.gameObject.tag==("Ground"))
        {
            animator.SetBool("IsFloating", false);
            animator.SetBool("IsFalling", false);
           
        }
        else
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsFalling", true);
        }
    }


    private bool IsGrounded()
    {
        // Debug.Log("HitGround");
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

        private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EvilBubble"))
        {
            collected++;
            collision.gameObject.SetActive(false);
            EBCounter.text = collected + "/" + remainingEB;
            collect.Play();

        }

        if (collision.CompareTag("Death"))
        {
            rb.transform.position = spawnPoint.transform.position;
        }
    }
    public float GetPowerProportion()
    {
        return currentPower / maxPower;
    }
   
}
