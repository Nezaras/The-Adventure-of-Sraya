using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraNew : MonoBehaviour
{
	public float SensitivityX;
	public float SensitivityY;
	
	private float _rotateX;
	private float _rotateY;
	private float _scrollY;
	
	public Transform _target;
	
	public float _Distance;
	private bool moveCharYes = true;
	
    // Start is called before the first frame update
    void Start()
    {
        Screen.lockCursor = true;
    }

    // Update is called once per frame
    void Update()
    {
		if(moveCharYes){
			moveChar();
		}
		if(Input.GetKeyUp(KeyCode.LeftAlt)){
			moveCharYes = !moveCharYes;
			Screen.lockCursor = moveCharYes;
		}
    }
	
	void moveChar(){
		float mouseY = Input.GetAxis("Mouse X") * SensitivityX;
		float mouseX = Input.GetAxis("Mouse Y") * SensitivityY;
		float mouseScroll = Input.mouseScrollDelta.y;
		
		_rotateX += -mouseX;
		_rotateY += mouseY;
		_scrollY += -mouseScroll;
		
		//Debug.Log(_rotateY);
		
		_rotateX = Mathf.Clamp(_rotateX, -5, 30);
		//_rotateY = Mathf.Clamp(_rotateY, -90, 90);
		_scrollY = Mathf.Clamp(_scrollY, 4, 30);
		
		transform.localEulerAngles = new Vector3(_rotateX, _rotateY, 0);
		
		transform.position = _target.position - transform.forward * _scrollY;
	}
}
