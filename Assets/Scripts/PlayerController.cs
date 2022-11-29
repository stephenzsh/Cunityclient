using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirection),typeof(Damageable))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 8f;

    TouchingDirection touchingDirections;

    Damageable damageable;
    public float CurrentMoveSpeed { get
        {
            if (CanMove)
            {
                if (touchingDirections.IsGrounded)
                {
                    if (_isWalking)
                    {
                        return runSpeed;
                    } else { 
                        return walkSpeed;
                    }
                }
                else
                {
                    return walkSpeed;
                }
                
            } else
            {
                return 0;
            }
        }

    }

    Vector2 moveInput;

    [SerializeField]
    private bool _isWalking = false;

    public bool IsWalking { get
        {
            return _isWalking;
        }
        private set {
            _isWalking = value;
            animator.SetBool(AnimationStrings.isWalking, value);
        }
    }


    private bool _isFacingRight = true;
    public bool IsFacingRight { get { return _isFacingRight; }
        private set {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }

    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }
    public bool IsAlive
    {
        get
        {
            return animator.GetBool(AnimationStrings.isAlive);
        }
    }

    public bool LockVelocity { get {
            return animator.GetBool(AnimationStrings.lockVelocity);
        }
        set
        {
            animator.SetBool(AnimationStrings.lockVelocity,value);
        }
    }

    Rigidbody2D rb;
    Animator animator;
    public float jumpImpulse = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirection>();
        damageable = GetComponent<Damageable>();
    }


    private void FixedUpdate()
    {

        if (!LockVelocity)
        {
            rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed * Time.fixedDeltaTime, rb.velocity.y);
        }

    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (IsAlive)
        {

            IsWalking = moveInput != Vector2.zero;

            SetFacingDirection(moveInput);
        } else
        {
            IsWalking = false;
        }


    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x >0 && !IsFacingRight)
        {
            //FACE THE RIGHT
            IsFacingRight = true;
        } else if (moveInput.x < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && touchingDirections.IsGrounded && CanMove)
        {
            animator.SetTrigger(AnimationStrings.jumpTrigger);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
            
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.attackTrigger);
        }
    }

    public void OnHit(int damage,Vector2 knockback)
    {
        LockVelocity = true;
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);

    }


}
