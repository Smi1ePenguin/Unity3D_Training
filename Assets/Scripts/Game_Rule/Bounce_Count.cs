using UnityEngine;
using TMPro;

public class Bounce_Count : MonoBehaviour
{
    public TextMeshProUGUI text;
    public BallStat ballstat;

    private void Start()
    {
        ballstat.ball_bounced = 0;
        text.text = "Bounce : " + ballstat.ball_bounced.ToString();
    }

    public void CountUp()
    {
        ballstat.ball_bounced++;
        text.text = "Bounce : " + ballstat.ball_bounced.ToString();
    }


}
