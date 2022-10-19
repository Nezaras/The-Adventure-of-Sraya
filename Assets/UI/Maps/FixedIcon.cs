using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedIcon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 rotation = Quaternion.LookRotation(transform.position).eulerAngles;
		rotation.x = 90f;
		rotation.y = 0f;
		 
		transform.rotation = Quaternion.Euler(rotation);
    }
}
