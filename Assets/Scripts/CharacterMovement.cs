using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public bool canMove;
    public bool isMove;
	public float speedCamera;

    [SerializeField] CharacterController controller;
    [SerializeField] PickupAndDrop pickupAndDrop;

    private Animator anim;

    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    private float _jumpHeight = 1.0f;
    private float _gravityValue = -9.81f;
	
	public Transform VirtualCamera;
	
	//yang ditambah
	private float _MoveY;
    private bool isRun = false;

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
        Run();
    }

    void Move()
    {
        if (canMove)
        {
			//yang ditambah (start)
			_MoveY = VirtualCamera.eulerAngles.y;
			_MoveY = (_MoveY > 180) ? _MoveY - 360 : _MoveY;
			
			Vector3 move = Quaternion.Euler (0, VirtualCamera.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
			
			//yang ditambah (end)

            move.Normalize();
			
            controller.Move(playerSpeed * Time.deltaTime * move);

            _playerVelocity.y += _gravityValue * Time.deltaTime;
            controller.Move(_playerVelocity * Time.deltaTime);

            if (move != Vector3.zero)
            {
                pickupAndDrop.canDrop = false;
                isMove = true;

                if (!pickupAndDrop.hasItem)
                {
                    anim.SetFloat("Movement", 1f);
                }
                else
                {
                    anim.SetFloat("MovingWhenGrab", 1f);
                }

				//move.y = _MoveY;
				transform.forward = move;
            }
            else
            {
                pickupAndDrop.canDrop = true;
                isMove = false;

                if (!pickupAndDrop.hasItem)
                {
                    anim.SetFloat("Movement", 0f);
                }
                else
                {
                    anim.SetFloat("MovingWhenGrab", 0f);
                }

                anim.SetBool("Push", false);
            }
        }
        else
        {
            anim.SetFloat("Movement", 0f);
            anim.SetFloat("MovingWhenGrab", 0f);
            anim.SetBool("Push", false);
        }
    }

    void Run(){
        if(Input.GetKeyDown(KeyCode.LeftShift) && !isRun){
            isRun = true;
            playerSpeed = 6f;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) && isRun){
            isRun = false;
            playerSpeed = 2.5f;
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