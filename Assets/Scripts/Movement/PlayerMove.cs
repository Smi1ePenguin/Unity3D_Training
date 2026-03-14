using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("상위 스크립트 PlayerMoveService 연결")]
    public PlayerMoveService moveService;
     
    private Rigidbody rb;
    private Vector3 movement;
    
    private void OnEnable()
    {
        moveService?.initialize();
        moveService.OnMoveInput += ControllMove;
    }
    private void OnDisable()
    {
        moveService?.end();
        moveService.OnMoveInput -= ControllMove;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void ControllMove(Vector3 moveInput)
    {
        movement = moveInput;
    }

    private void FixedUpdate()
    {
        Vector3 Velocity = movement * moveService.stat.moveSpeed;
        Velocity.y = rb.linearVelocity.y;
        rb.linearVelocity = new Vector3(Velocity.x, rb.linearVelocity.y, Velocity.z);
    }
}