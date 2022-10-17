using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraMiniMaps : MonoBehaviour
{	
	public float SpeedMovement;
	
	public Transform _target;
	
	public float _Distance; 		
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		moveMiniMaps();
    }
	
	void moveMiniMaps(){
		transform.position = _target.position - transform.forward;
	}
}
