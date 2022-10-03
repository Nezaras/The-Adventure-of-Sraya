using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
	public float SensitivityX;
	public float SensitivityY;
	
	private float _rotateX;
	private float _rotateY;
	private float _scrollY;
	
	public Transform _target;
	
	public float _Distance;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse X") * SensitivityX;
		float mouseX = Input.GetAxis("Mouse Y") * SensitivityY;
		float mouseScroll = Input.mouseScrollDelta.y;
		
		_rotateX += -mouseX;
		_rotateY += mouseY;
		_scrollY += -mouseScroll;
		
		//Debug.Log(_rotateY);
		
		_rotateX = Mathf.Clamp(_rotateX, 0, 40);
		//_rotateY = Mathf.Clamp(_rotateY, -40, 40);
		_scrollY = Mathf.Clamp(_scrollY, 4, 10);
		
		transform.localEulerAngles = new Vector3(_rotateX, _rotateY, 0);
		
		transform.position = _target.position - transform.forward * _scrollY;
    }
}
