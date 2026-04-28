using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Bounce_Count : MonoBehaviour
{
    public TextMeshPro text;
    public InputActionReference jumpAction;
    public BallStat ballstat;

     void OnEnable()
    {
        jumpAction.action.Enable();
        jumpAction.action.performed += OnJump;
    }
    void OnDisable()
    {
        jumpAction.action.Disable();
        jumpAction.action.performed -= OnJump;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        ballstat.ball_bounced++;
        text.text = ballstat.ball_bounced.ToString();
    }


}
