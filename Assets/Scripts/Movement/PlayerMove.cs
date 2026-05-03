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
        rb.AddForce(movement * moveService.stat.moveSpeed, ForceMode.Force);
        Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (flatVelocity.magnitude > moveService.stat.maxSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveService.stat.maxSpeed;
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
        }

        if(rb.linearVelocity.y < 0)
        {   
            rb.AddForce(Physics.gravity * rb.mass * 2.5f, ForceMode.Force);    //낙하 가속도 증가
        }
    }
}