using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerDash : MonoBehaviour
{
    [Header("상위 스크립트 PlayerMoveService 연결")]
    public PlayerMoveService moveService;

    private Rigidbody rb;
    private Vector3 movement;
    private void OnEnable()
    {
        moveService?.initialize();
        moveService.OnMoveInput += ContorllMove;
        moveService.DashAction.action.performed += OnDash;
    }

    private void OnDisable()
    {
        moveService.OnMoveInput -= ContorllMove;
        moveService.DashAction.action.performed -= OnDash;
        moveService?.end();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void ContorllMove(Vector3 moveInput)
    {
        movement = moveInput;
    }

    private void OnDash(InputAction.CallbackContext context)
    {
        rb.AddForce(movement * moveService.stat.dashPower, ForceMode.Impulse);
    }
}
