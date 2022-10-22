using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[ExecuteInEditMode()]
public class ParameterKebaikan : MonoBehaviour
{
    public int current;

    [SerializeField] int min;
    [SerializeField] int max;

    [SerializeField] Image fill;

    void Update()
    {
        GetCurrentFill();

        if(current == max)
        {
            SceneManager.LoadScene("Epilog");
        }
    }

    void GetCurrentFill()
    {
        float currentOffset = current - min;
        float maxOffset = max - min;
        float fillAmount = currentOffset / maxOffset;
        fill.fillAmount = fillAmount;
    }
}
