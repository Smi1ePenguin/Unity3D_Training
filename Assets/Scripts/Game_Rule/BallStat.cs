using UnityEngine;

[CreateAssetMenu(fileName = "BallStat", menuName = "Scriptable Objects/BallStat")]
public class BallStat : ScriptableObject
{
    [Header("Move")]
    public float moveSpeed = 10f;
    public float maxSpeed = 10f;
    public float jump = 7f;
    public int ball_bounced = 0;
    public int max_bounce = 100;

    [Header("Appearance")]
    public Color ballColor = Color.white;
    public float ballSize = 1f;

}
