using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyunanTrigger : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject ayunanAnim;
    [SerializeField] GameObject ayunanStatic;
    [SerializeField] GameObject playText;
    [SerializeField] GameObject stopText;

    bool isPlaying;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPlaying)
            {
                player.SetActive(false);

                playText.SetActive(false);
                stopText.SetActive(true);

                ayunanStatic.SetActive(false);
                ayunanAnim.SetActive(true);
                isPlaying = true;
            }
            else
            {
                player.SetActive(true);

                stopText.SetActive(false);
                playText.SetActive(true);

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
            playText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playText.SetActive(false);
        }
    }
}
