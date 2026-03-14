using UnityEngine;

[CreateAssetMenu(fileName = "BallStat", menuName = "Scriptable Objects/BallStat")]
public class BallStat : ScriptableObject
{
    [Header("Move")]
    public float moveSpeed = 10f;
    
    public float jump = 7f;
    public float dashPower = 1.5f;

    [Header("Appearance")]
    public Color ballColor = Color.white;
    public float ballSize = 1f;
}
