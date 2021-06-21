using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Joystick joystick;
    public bool canGo = true;


    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private Transform groundChecker;
    [SerializeField]
    private PlayerSound playerSound;
    private bool isJump = false;
    private Animator _animation;
    private Rigidbody2D _rbPlayer;

    private void Start()
    {
        GetReferences();
    }

    // Update is called once per frame
    private void Update()
    {
        if (canGo)
        {
            CheckGround();
            CheckDeathZone();
            Jump();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(canGo)
            Move();
    }

    private void Move()
    {
        if (Input.GetAxis("Horizontal") > 0 || joystick.Horizontal >= 0.2f)
            _rbPlayer.velocity = new Vector2(playerSpeed * Time.deltaTime, _rbPlayer.velocity.y);
        else if (Input.GetAxis("Horizontal") < 0 || joystick.Horizontal <= -0.2f)
            _rbPlayer.velocity = new Vector2(-playerSpeed * Time.deltaTime, _rbPlayer.velocity.y);
        else
            _rbPlayer.velocity = new Vector2(0f, _rbPlayer.velocity.y);

        if (Input.GetAxis("Horizontal") == 0 && joystick.Horizontal == 0)
        {
            _animation.SetInteger("state", 0);
        }
        else
        {
            Flip();
            _animation.SetInteger("state", 3);
        }

    }

    public void JumpJoystick()
    {
        if (isJump)
        {
            playerSound.PlayJumpSound();
            _animation.SetInteger("state", 1);
            _rbPlayer.AddForce(Vector2.up * jumpHeight, ForceMode2D.Force);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isJump)
        {
            playerSound.PlayJumpSound();
            _animation.SetInteger("state", 1);
            _rbPlayer.AddForce(Vector2.up * jumpHeight, ForceMode2D.Force);
        }

        if (Input.GetButtonUp("Jump") && isJump)
            _animation.SetInteger("state", 2);
    }

    private void CheckDeathZone()
    {
        if(transform.position.y <= -11.5f)
        {
            GetComponent<PlayerHealth>().TakeDamage(-1000);
        }
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundChecker.position, 0.2f);
        isJump = colliders.Length > 1;
    }

    private void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0 || joystick.Horizontal >= 0.2f)
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        if (Input.GetAxis("Horizontal") < 0 || joystick.Horizontal <= -0.2f)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    private void GetReferences()
    {
        _animation = GetComponent<Animator>();
        _rbPlayer = GetComponent<Rigidbody2D>();
        _animation.SetInteger("state", 0);
    }
}
