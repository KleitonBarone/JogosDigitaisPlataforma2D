using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int speedParam = Animator.StringToHash("Speed");
    private int YParam = Animator.StringToHash("YForce");
    private int groundedParam = Animator.StringToHash("IsGrounded");

    public int coins = 0;
    public float speedForce = 12.0f;
    public float jumpForce = 5.0f;

    public bool IsDoubleJumpReady = false;
    private float _deltaTime = 0f;
    public float targetTime = 0.1f;
    public float DoubleJumpMultiplier = 2f;

    public bool IsGrounded = false;
    public Vector3 offset = Vector2.zero;
    public float raidios = 1.0f;
    public LayerMask layer;
    public float logVelocity;

    private Vector2 _input = Vector2.zero;
    private Vector2 _direction = Vector2.zero;
    public Vector2 _moviment = Vector2.zero;
    private Rigidbody2D _body = null;
    private Animator _animator = null;
    private SpriteRenderer _renderer = null;
    



    // Awake is called when the script instance is being loaded
    private void Awake()
    {        
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // OnTriggerEnter2D é chamado quando outro Collider2D entra no gatilho (somente física de 2D)
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.CompareTag("Coins")) 
        {
            coins++;
            Destroy(collision.gameObject);
        }
    }



    // Update is called once per frame
    void Update()
    {
        _deltaTime += Time.deltaTime;
        _moviment = new Vector2(Input.GetAxisRaw("Horizontal") * speedForce, 0.0f);
     
        if (_moviment.sqrMagnitude > 0.1f)
        {           
            _renderer.flipX = !(Input.GetAxis("Horizontal") > 0.0f);            
        }
        
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            IsDoubleJumpReady = true;
        }

        if(Input.GetButtonDown("Jump") && !IsGrounded && _deltaTime > targetTime && IsDoubleJumpReady) {
            if( _body.velocity.y < 0f ) {
                _body.AddForce( new Vector2(0.0f, -_body.velocity.y), ForceMode2D.Impulse);
            }  
            
            _deltaTime = 0;
            
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            IsDoubleJumpReady = false;
        }
        
        _animator.SetFloat(speedParam, Mathf.Abs(_body.velocity.x));
        _animator.SetFloat(YParam, _body.velocity.y);
        _animator.SetBool(groundedParam, IsGrounded);
    }



    private void FixedUpdate()
    {

        IsGrounded = Physics2D.OverlapCircle(this.transform.position + offset, raidios, layer);
        logVelocity = _body.velocity.x;

        if (_moviment.sqrMagnitude > 0.1f)
        {
            if (_body.velocity.x < 7.0f && _body.velocity.x > -7.0f)
            {
                _body.AddForce(_moviment, ForceMode2D.Force);
            }
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((this.transform.position + offset), raidios);

    }




}

