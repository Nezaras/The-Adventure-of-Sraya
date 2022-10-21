using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyunanTrigger : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject ayunanAnim;
    [SerializeField] GameObject ayunanStatic;
    [SerializeField] GameObject canvasAyunan;

    bool isPlaying;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPlaying)
            {
                player.SetActive(false);
                ayunanStatic.SetActive(false);
                ayunanAnim.SetActive(true);
                isPlaying = true;
            }
            else
            {
                player.SetActive(true);
                ayunanAnim.SetActive(false);
                ayunanStatic.SetActive(true);
                isPlaying = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasAyunan.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasAyunan.SetActive(false);
        }
    }
}
