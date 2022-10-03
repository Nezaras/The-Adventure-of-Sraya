using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
	private Rigidbody rig; 
	
	private Vector3 speed;
	public float _SpeedMovement;
	private float _rotateX;
	
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		//speed = Vector3.zero;
		
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(x, 0, z) * _SpeedMovement;
		
		_rotateX += x;
		
		if (x != 0 || z != 0)
		 {
			 rig.MoveRotation(Quaternion.LookRotation(movement));
		 }
		 rig.velocity = movement;
        //transform.Translate(movement * SpeedMovement * Time.deltaTime);
    }
	
	void Movement()
	{
				if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) 
				{ 
					speed = new Vector3(_SpeedMovement, 0f, _SpeedMovement);
				}
				else if (Input.GetKey(KeyCode.W)){
					speed = Vector3.forward * _SpeedMovement;
				}
				else if (Input.GetKey(KeyCode.D)){
					speed = Vector3.right * _SpeedMovement;
				}
				
				if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) 
				{ 
					speed = new Vector3(-_SpeedMovement, 0f, _SpeedMovement);
				}
				else if (Input.GetKey(KeyCode.W)){
					speed = Vector3.forward * _SpeedMovement;
				}
				else if (Input.GetKey(KeyCode.A)){
					speed = Vector3.left * _SpeedMovement;
				}
				
				if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) 
				{ 
					speed = new Vector3(_SpeedMovement, 0f, -_SpeedMovement);
				}
				else if (Input.GetKey(KeyCode.S)){
					speed = Vector3.back * _SpeedMovement;
				}
				else if (Input.GetKey(KeyCode.D)){
					speed = Vector3.right * _SpeedMovement;
				}
				
				
				if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) 
				{ 
					speed = new Vector3(-_SpeedMovement, 0f, -_SpeedMovement);
				}
				else if (Input.GetKey(KeyCode.S)){
					speed = Vector3.back * _SpeedMovement;
				}
				else if (Input.GetKey(KeyCode.A)){
					speed = Vector3.left * _SpeedMovement;
				}
				
				
	}
}
