using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapKlick : MonoBehaviour
{
	public GameObject largeMapObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){ // if left button pressed...
            largeMapObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.M)){
            if(!largeMapObject.activeInHierarchy){
                largeMapObject.SetActive(true);
            }else{
                largeMapObject.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.M)){ // if left button pressed...
            largeMapObject.SetActive(false);
        }
    }
}
