using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public bool canMove;
    public bool isMove;

    [SerializeField] CharacterController controller;

    private Animator anim;

    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    private float _jumpHeight = 1.0f;
    private float _gravityValue = -9.81f;
    

    private void Start()
    {
        anim = GetComponent<Animator>();
        canMove = true;
    }

    void Update()
    {
        _groundedPlayer = controller.isGrounded;
        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        Move();
        //Jump();
    }

    void Move()
    {
        if (canMove)
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                isMove = true;
                //anim.SetFloat("Movement", 0.5f);
                gameObject.transform.forward = move;
            }
            else
            {
                isMove = false;
                //anim.SetFloat("Movement", 0f);
            }
        }
    }

    void Jump()
    {
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        controller.Move(_playerVelocity * Time.deltaTime);
    }
}