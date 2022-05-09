using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public static float moveSpeed;
    public static float resawnMoveSpeed;
    private bool jump;
    private int frames;
    private float jumpForce;
    private float gravityForce;
    private float horizontalInput;
    private Animator _animator;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    private int frameCounter;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        if (Events.isRespawnPlayer)
        {
            moveSpeed = resawnMoveSpeed;
            Events.isRespawnPlayer = false;
        }
        else
        {
            moveSpeed = 5;
        }
        resawnMoveSpeed = 0;
    }
    public void makeJump()
    {
        jump = true;
    }
    public void moveRight()
    {
        horizontalInput = 1;
    }
    public void moveLeft()
    {
        horizontalInput = -1;
    }
    public void dontMove()
    {
        horizontalInput = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (Events.isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        /*if (Events.isRespawn)
        {
            Events.isRespawn = false;
        }*/
        if (moveSpeed < 15) //Speedup Game
        {
            moveSpeed = moveSpeed + 0.01f * Time.deltaTime;
        }
        if (moveSpeed >= resawnMoveSpeed)
        {
            resawnMoveSpeed = moveSpeed;
        }

        //horizontalInput = Input.GetAxis("Horizontal");
        _animator.SetBool("IsGrounded", IsGrounded());
        jumpForce = (2 * 6 * moveSpeed) / 3.3f;
        decimal dec = new decimal(moveSpeed);
        double d = (double)dec;
        float e = (float)Math.Pow(d, 2);
        float f = (float)Math.Pow(3.3, 2);
        gravityForce = (2 * 6 * e) / f;
        Physics.gravity = new Vector3(0, -gravityForce, 0);
        /*if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }*/
        if (_rigidbody.position.y < -10f)
        {
            //Time.timeScale = 0;
            //this.enabled = false;
            moveSpeed = 0;
            gameOverPanel.SetActive(true);
            _animator.enabled = false;
        }
        if (_rigidbody.velocity.z == 0 && frameCounter > 100)
        {
            //Time.timeScale = 0;
            //this.enabled = false;
            moveSpeed = 0;
            gameOverPanel.SetActive(true);
            _animator.enabled = false;
        }
        else
        {
            frameCounter++;
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
    private void FixedUpdate()
    {
        if (_rigidbody.transform.position.x > -2.6f && _rigidbody.transform.position.x < 2.6f)
            _rigidbody.velocity = new Vector3(-horizontalInput * moveSpeed, _rigidbody.velocity.y, -moveSpeed);
        else
        {
            if (_rigidbody.transform.position.x <= -2.6f)
            {
                _rigidbody.velocity = new Vector3(1, _rigidbody.velocity.y, -moveSpeed);
            }

            if (_rigidbody.transform.position.x >= 2.6f)
            {
                _rigidbody.velocity = new Vector3(-1, _rigidbody.velocity.y, -moveSpeed);
            }
        }

        // _rigidbody.MovePosition(new Vector3(transform.position.x + -horizontalInput, transform.position.y, transform.position.z));
        //transform.Translate(Vector3.forward * Time.deltaTime * -moveSpeed, Space.World);
        //_rigidbody.MovePosition(new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * -moveSpeed));
        jumpForce = (2 * 6 * moveSpeed) / 3.3f;
        if (jump && IsGrounded())
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, jumpForce, -moveSpeed);
            jump = false;
        }

    }

}
