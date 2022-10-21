using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    private bool isNear;
    private bool isOpen;
    public GameObject canvas;
    public GameObject tas;
    public GameObject konfirmasiShop;
    public GameObject sraya;

    // Start is called before the first frame update
    void Start()
    {
        isNear = true;
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isNear){
            if(Input.GetKeyDown(KeyCode.B)){
                tas.SetActive(!isOpen);
                isOpen = !isOpen;

                GameObject.Find("FollowCam").GetComponent<MoveCameraNew>().moveCharYes = false;
                Screen.lockCursor = false;
            }
            if(Input.GetKeyDown(KeyCode.Escape)){
                if(konfirmasiShop.activeSelf){
                    konfirmasiShop.SetActive(false);
                }else{
                    isOpen = false;
                    tas.SetActive(false);
                }
            }
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
            isNear = true;
            canvas.SetActive(false);
        }
    }
}
