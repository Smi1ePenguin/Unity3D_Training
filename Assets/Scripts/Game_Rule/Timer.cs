using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [Header("타이머")]
    public TextMeshProUGUI timerText;
    
    private float currentSeconds = 0f;

    private void Update()
    {
        currentSeconds += Time.deltaTime;

        int hours = Mathf.FloorToInt(currentSeconds / 3600f);
        int minutes = Mathf.FloorToInt(currentSeconds / 60f);
        int seconds = Mathf.FloorToInt(currentSeconds % 60f);

        timerText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
    }
}
