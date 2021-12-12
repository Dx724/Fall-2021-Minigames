using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class dummy_movement : MonoBehaviour
{
    
    Collider2D playerCollider;
    private Rigidbody2D rb;
    private int count;
    public LayerMask ground;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f; 
    public float jumpForce = 2f;
    private Animator anim;
    public bool grounded;
    private bool facingLeft = false;
    float cameraBottomBounds;
    public TextMeshProUGUI ScoreText;
    public GameObject coinCollected;

    [SerializeField] private Transform bottomBounds;


    Vector2 moveVector;

    [SerializeField]
    float _horizontalAcceleration = 20f; // meters per second per second

    [SerializeField]
    float _maxHorizontalSpeed = 10f;

    [SerializeField]
    float _horizontalDrag = 0.2f; 

    [SerializeField]
    float _jumpHeight = 5f; // in meters

    [SerializeField]
    float _jumpTime = 1f; // in seconds

    [SerializeField]
    float _floorcastFudgeFactor = 0.23f; // magic number found through playtesting

    [SerializeField]
    float _gravityScaleInfluence = 0.75f; // how much of rigid body's gravity scale to take into account

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

        count = 0;
        SetCountText();

        rb.freezeRotation = true; 
        anim = GetComponent<Animator>();

        cameraBottomBounds = Camera.main.ViewportToWorldPoint(new Vector3 (1f, 1f, 0f)).y;

    }


    void Update(){
        anim.SetBool("grounded", grounded);
        //Debug.Log("Player Position: X = " + transform.position.x + " --- Y = " + transform.position.y);
        if (transform.position.y > count)
        {
            count = (int) Mathf.Floor(transform.position.y);
            SetCountText();
        }        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = detectGround();
        if (grounded){
            // Jump();
            // BetterJump();
            rb.AddForce(Vector2.up * CalculateJumpForce());
        }

        //Vector2 moveRaw = res.Get<Vector2>();
        //Vector2 LateralMove = new Vector2(moveRaw.x, 0);

        //float currentPositionY = transform.position.y;
        // transform.position = new Vector3(transform.position.x,transform.position.y , transform.position.z) + moveVector*0.2f;
        //  Physics2D.IgnoreLayerCollision(0,3, (rb.velocity.y>0.0f));
        // Debug.Log(rb.velocity.y);

        if (Mathf.Sign(rb.velocity.x) != Mathf.Sign(moveVector.x) ||
            Mathf.Abs(rb.velocity.x) < _maxHorizontalSpeed)
        {
            rb.velocity += moveVector * _horizontalAcceleration * Time.deltaTime;
        }

        if (moveVector.x == 0f)
        {
            rb.velocity -= rb.velocity.x * _horizontalDrag * Vector2.right;
        }

        anim.SetFloat("y_velocity", rb.velocity.y);
        if (moveVector.x < 0 && facingLeft || moveVector.x  > 0 && !facingLeft)
        {
            flip();
        }


        if (transform.position.y < bottomBounds.position.y)
        {
            Debug.Log("Dead because you fell");
            PlayerPrefs.SetInt("SheepScore", count);
            SceneManager.LoadScene("GameOver");
        }
        
    }
    void flip()
    {
        facingLeft = !facingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    float CalculateJumpForce()
    {
        /*
            F = (mass (targetVelocity - current_velocity)) / Time.deltaTime

         */

        // doesnt' work perfectly but if you play with the jump inputs 
        // you can get good results

        float h = _jumpHeight;
        float t_flight = _jumpTime;

        float vf = h / t_flight + 0.5f * Physics.gravity.magnitude * rb.gravityScale * _gravityScaleInfluence * t_flight;

        float m = rb.mass;
        float v0 = rb.velocity.y;
        float t_impulse = Time.deltaTime; 

        return m * (vf - v0) / t_impulse; 
    }
   

    bool detectGround()
    {
        float size = playerCollider.bounds.extents.magnitude; 

        Vector3 playerPosLeft = playerCollider.bounds.center - playerCollider.bounds.extents;
		Vector3 playerPosRight = new Vector3(playerPosLeft.x + 2f * playerCollider.bounds.extents.x, playerPosLeft.y, playerPosLeft.z);
		RaycastHit2D left = Physics2D.Raycast(playerPosLeft, Vector2.down, _floorcastFudgeFactor * size, ground);
		RaycastHit2D right = Physics2D.Raycast(playerPosRight, Vector2.down, _floorcastFudgeFactor * size, ground);


		Color rayColor;
		if (left.collider != null || right.collider != null)
		{
		   rayColor = Color.green;
		}
		else
		{
		   rayColor = Color.red;
		}	

		Debug.DrawRay(playerPosLeft, Vector2.down * _floorcastFudgeFactor * size, rayColor);
		Debug.DrawRay(playerPosRight, Vector2.down * _floorcastFudgeFactor * size, rayColor);
		
		return (left.collider != null || right.collider != null);
    }

    void Jump() 
    { 
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
    } 

    void BetterJump()
    {
		if (rb.velocity.y < 0)
		{
		    rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
		}
		else if (rb.velocity.y > 0)
		{
		    rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("collision");
    //    if (other.gameObject.CompareTag("Monster"))
    //    {
    //        Debug.Log("dead because of monster");
    //        SceneManager.LoadScene("GameOver");
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            int currentCoins = PlayerPrefs.GetInt("coins");
            PlayerPrefs.SetInt("coins", currentCoins++);

            count += 10;
            SetCountText();
            
            Vector3 spawnCoinCollectedLoc = transform.position + new Vector3(0f, 5f, 0f);
            Instantiate(coinCollected, spawnCoinCollectedLoc, Quaternion.identity);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            Debug.Log("monster");

            var normal = collision.GetContact(0).normal;
            float dot = Vector2.Dot(collision.gameObject.transform.up, normal);

            rb.AddForce(normal.normalized * 1.2f * CalculateJumpForce());

            // did we jump on the monster?
            if (1f - dot <= 0.5f)
            {
                Destroy(collision.gameObject);
                Debug.Log("Above");
            } else
            {
                Debug.Log("Below");
                PlayerPrefs.SetInt("SheepScore", count);
                SceneManager.LoadScene("GameOver");
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void OnMovementChange(InputAction.CallbackContext context){
        Vector2 direction = context.ReadValue<Vector2>();
        moveVector = new Vector3(direction.x, 0, direction.y);
    }
    
    public void OnStartGame(InputAction.CallbackContext context)
    {
        if (SceneManager.GetActiveScene().name == "HomeScreen")
        {
            Buttons.OnStart();
        }
    }

    void SetCountText()
	{
		ScoreText.text = "Score: " + (count*10).ToString();
	}

}
