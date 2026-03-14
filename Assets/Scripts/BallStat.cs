using UnityEngine;

[CreateAssetMenu(fileName = "BallStat", menuName = "Scriptable Objects/BallStat")]
public class BallStat : ScriptableObject
{
    [Header("Move")]
    public float moveSpeed = 10f;
    
    public float jump = 7f;
    public float sprint_multiplier = 1.5f;
}
