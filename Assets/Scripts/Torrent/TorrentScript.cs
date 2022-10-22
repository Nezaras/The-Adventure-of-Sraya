using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorrentScript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject pipePuzzle;

    bool isNear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isNear){
            pipePuzzle.SetActive(true);
            
            Cursor.lockState = CursorLockMode.None;
            GameObject.Find("FollowCam").GetComponent<MoveCameraNew>().moveCharYes = false;
            GameObject.Find("NewSraya").GetComponent<CharacterMovement>().canMove = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = true;
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
            canvas.SetActive(false);
        }
    }
}
