using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class PlayerJump : MonoBehaviour
{
    [Header("상위 스크립트 PlayerMoveService 연결")]
    public PlayerMoveService moveService;

    [Header("입력 세팅")]
    public InputActionReference jumpAction;

    [Header("슈퍼 점프 강도")]
    public float SuperJumpPower = 20f;

    [Header("음향 효과 발생 임계점")]
    public float soundThreshold = 2f;

    public UnityEvent onJump;
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
    private void FixedUpdate()
    {
        if(!IsGrounded() && rb.linearVelocity.y < 0)
        {
            rb.linearDamping = 1f;
        }
        else
        {
            rb.linearDamping = 3f;
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.23f);
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * moveService.stat.jump, ForceMode.Impulse);
            onJump?.Invoke();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Instant Jump Plate"))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

            rb.AddForce(Vector3.up * SuperJumpPower, ForceMode.Impulse);
        }
        else
        {
            if (collision.relativeVelocity.magnitude > soundThreshold)
            {
                var audioService = AudioServiceLocator.Get<IAudioManager>();
                audioService.PlaySound("Land");
            }
        }
    }
}