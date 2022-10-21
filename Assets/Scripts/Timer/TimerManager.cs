using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] Text countdownText;
    [SerializeField] GameObject popupFail;
    [SerializeField] GameObject popupTimer;
    [SerializeField] ParameterKebaikan parameter;

    [HideInInspector]
    public bool timerCount;
    [HideInInspector]
    public bool isLose;
    [HideInInspector]
    public bool isWin;
    [HideInInspector]
    public float timer;

    private void Start()
    {
        timer = 0.1f;
    }

    private void FixedUpdate()
    {
        timer = Mathf.Clamp(timer, 0, 1000);

        if (timerCount)
        {
            timer -= 1 * Time.fixedDeltaTime;
            DisplayTime(timer);
        }

        if (isWin)
        {
            timer = 0.1f;

            isWin = false;
        }

        if (timer <= 0.0f)
        {
            isLose = true;
            if (isLose)
            {
                //Lose Condition
                popupFail.SetActive(true);
                timerCount = false;

                isLose = false;
            }
            timer = 0.2f;
        }            
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        popupTimer.SetActive(true);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddTimer(float setTimer)
    {
        timer = setTimer;
    }
}
