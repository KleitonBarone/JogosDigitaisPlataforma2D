using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    private int speedParam = Animator.StringToHash("Speed");
    private int YParam = Animator.StringToHash("YForce");
    private int groundedParam = Animator.StringToHash("IsGrounded");
    private int isFiring = Animator.StringToHash("isFiring");

    public int coins = 0;
    public float speedForce = 5.0f;
    public float jumpForce = 5.0f;

    public float maxSpeed = 8.0f;

    public bool IsDoubleJumpReady = false;
    private float _deltaTimeJump = 0f;
    public float targetTimeJump = 0.1f;
    public float DoubleJumpMultiplier = 2f;

    private float _deltaTimeAttack = 0f;
    public float targetTimeAttack = 1f;

    public bool IsGrounded = false;
    public bool isAttacking = false;
    public Vector3 offset = Vector2.zero;
    public float raidios = 1.0f;
    public float logSpeed = 0f;
    public LayerMask layer;
    public Text coinsScore;

    private Vector2 _input = Vector2.zero;
    private Vector2 _direction = Vector2.zero;
    private Vector2 _moviment = Vector2.zero;
    private Vector2 _jump = Vector2.zero;
    private Rigidbody2D _body = null;
    private Animator _animator = null;
    private SpriteRenderer _renderer = null;

    public Vector3 projectileOffset;
    public float projectileRadius = 1.0f;

    bool isRightFaced = true;
    public ObjectPooling objectPooling = new ObjectPooling();

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
        objectPooling.OnStart();
        GameManager aux = GameManager.Instance;
        //GameManager.Instance.LoadLevel("Demo");
    }

    // OnTriggerEnter2D � chamado quando outro Collider2D entra no gatilho (somente f�sica de 2D)
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.CompareTag("Coins")) 
        {
            Destroy(collision.gameObject);
            coins++;
            coinsScore.text = "x "+coins.ToString();
        }

    }



    // Update is called once per frame
    void Update()
    {
        _deltaTimeJump += Time.deltaTime;
        _deltaTimeAttack += Time.deltaTime;
        
        _moviment = new Vector2(Input.GetAxisRaw("Horizontal") * speedForce, 0.0f);
        _jump = Input.GetButtonDown("Jump") ? new Vector2(_body.velocity.x, 1 * jumpForce) : new Vector2(_body.velocity.x, 0 * jumpForce);

        if (_moviment.sqrMagnitude > 0.1f)
        {
            isRightFaced = (Input.GetAxis("Horizontal") > 0.0f);
            _renderer.flipX = !(Input.GetAxis("Horizontal") > 0.0f);            
        }
        
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            IsDoubleJumpReady = true;
        }

        if(Input.GetButtonDown("Jump") && !IsGrounded && _deltaTimeJump > targetTimeJump && IsDoubleJumpReady) {
            if( _body.velocity.y < 0f ) {
                _body.AddForce(  new Vector2(0.0f, -_body.velocity.y) - _body.velocity, ForceMode2D.Impulse);
            }  
            
            _deltaTimeJump = 0;
            
            _body.AddForce(_jump - _body.velocity, ForceMode2D.Impulse);
            IsDoubleJumpReady = false;
        }


        if (Input.GetButtonDown("Fire1") &&  _deltaTimeAttack > targetTimeAttack)
        {
            isAttacking = true;
            float faceFactor = (isRightFaced ? 1.0f : -1.0f);
            Vector3 projectileOffsetValue = new Vector3(projectileOffset.x * faceFactor, 0, 0);
            Vector3 projectilePosition = this.transform.position + projectileOffsetValue;
            Projectile projectile = ObjectPooling.GetProjectile();
            projectile.transform.position = projectilePosition;
            projectile.Shoot(isRightFaced);
            _deltaTimeAttack = 0;
        }
        else
        {
            isAttacking = false;
        }

        _animator.SetFloat(speedParam, Mathf.Abs(_body.velocity.x));
        _animator.SetFloat(YParam, _body.velocity.y);
        _animator.SetBool(groundedParam, IsGrounded);
        _animator.SetBool(isFiring, isAttacking);
    }



    private void FixedUpdate()
    {

        IsGrounded = Physics2D.OverlapCircle(this.transform.position + offset, raidios, layer);
        logSpeed = _body.velocity.x;
        if(_body.velocity.x < maxSpeed && _body.velocity.x > -maxSpeed) { //limita a velocidade em 8
            _body.AddForce(_moviment - _body.velocity, ForceMode2D.Force);
        }
        

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((this.transform.position + offset), raidios);

    }




}

