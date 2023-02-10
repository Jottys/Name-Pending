using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    #region Player Speeds
    [SerializeField]
    private float _playerSpeed = 140f;
    #endregion

    private bool _FacingRight = true;
    private Vector2 _playerVelocity;
    private bool _isJogging;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();        
    }


    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(_playerVelocity * Time.deltaTime);
        animator.SetBool("isJogging", _isJogging);

        if (moveInput != 0)
        {
            _playerVelocity.x = moveInput * _playerSpeed;
            _isJogging = true;
        }
        else
        {
            _playerVelocity.x = 0f;
            _isJogging = false;
        }

        if (moveInput < 0 && _FacingRight)
        {
            Flip();
        }
        if (moveInput > 0 && !_FacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector2 _currentScale = gameObject.transform.localScale;
        _currentScale.x *= -1;
        gameObject.transform.localScale = _currentScale;

        _FacingRight = !_FacingRight;
    }
}
