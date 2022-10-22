using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoSkip : MonoBehaviour
{
    public float duration;
    public string sceneName;

    void Start()
    {
        StartCoroutine(Skip());
    }

    IEnumerator Skip()
    {
        yield return new WaitForSeconds(duration);

        SceneManager.LoadScene(sceneName);
    }
}
