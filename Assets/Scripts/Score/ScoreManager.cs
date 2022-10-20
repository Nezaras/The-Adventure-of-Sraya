using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] ParameterKebaikan parameter;

    public bool isAdd;

    public void AddPoint()
    {
        parameter.current += 1;
    }
}
