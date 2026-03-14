using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerJump : MonoBehaviour
{
    public BallStat stat;
    public InputActionReference jumpAction;
    private Rigidbody rb;
    
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
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.23f);
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * stat.jump, ForceMode.Impulse);
        }
    }
}