using UnityEngine;

public class LargeMap : MonoBehaviour
{
	public GameObject largeMapObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            largeMapObject.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            largeMapObject.SetActive(false);
        }
    }
}
