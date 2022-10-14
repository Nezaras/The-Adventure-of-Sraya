using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] int[] correctRotation;
    [SerializeField] bool isStraight;
    public bool isTruePlaced;

    int[] rotations = { 0, 90, 180, 270 };
    PipeManager manager;

    private void Awake()
    {
        manager = GameObject.Find("PipeManager").GetComponent<PipeManager>();
    }

    void Start()
    {
        RandomRotation();
    }

    public void RotatePipe()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        CorrectChecker();
    }

    public void RandomRotation()
    {
        isTruePlaced = false;

        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        CorrectChecker();
    }

    void CorrectChecker()
    {
        Debug.Log(transform.eulerAngles.z);

        float z = transform.eulerAngles.z;
        int zRot = (int) z;        

        if (isStraight)
        {
            if (zRot == correctRotation[0] || zRot == correctRotation[1])
            {
                isTruePlaced = true;
                manager.CorrectMove();
            }
            else if (isTruePlaced)
            {
                isTruePlaced = false;
                manager.WrongMove();
            }
        }
        else
        {
            if (zRot == correctRotation[0])
            {
                isTruePlaced = true;
                manager.CorrectMove();
            }
            else if (isTruePlaced)
            {
                isTruePlaced = false;
                manager.WrongMove();
            }
        }
    }
}
