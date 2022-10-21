using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeManager : MonoBehaviour
{
    [SerializeField] Transform pipesParent;
    [SerializeField] GameObject[] pipes;
    [SerializeField] Button done;

    int totalPipes;
    [SerializeField] int correctedPipes;

    public bool isDone;

    void Start()
    {
        totalPipes = pipesParent.transform.childCount;

        pipes = new GameObject[totalPipes];

        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i] = pipesParent.transform.GetChild(i).gameObject;
        }
    }

    public void CorrectMove()
    {
        correctedPipes += 1;
        if (correctedPipes == totalPipes)
        {
            done.interactable = true;
            isDone = true;

            Screen.lockCursor = false;
            GameObject.Find("FollowCam").GetComponent<MoveCameraNew>().moveCharYes = true;
            GameObject.Find("NewSraya").GetComponent<CharacterMovement>().canMove = true;
        }
        else
        {
            done.interactable = false;
            isDone = false;
        }
    }

    public void WrongMove()
    {
        correctedPipes -= 1;
    }

    public void Reset()
    {
        correctedPipes = 0;
        int length = pipes.Length;

        for (int i = 0; i < length; i++)
        {
            pipes[i].GetComponent<Pipe>().RandomRotation();
        }
    }
}
