using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("스크립터블 오브젝트 연결")]
    public BallStat stat;
    [Header("입력 세팅")]
    public InputActionReference moveAction;
     
    private Rigidbody rb;
    private Vector3 movement;
    private Transform mainCamera;
    
    private void OnEnable()
    {
        moveAction.action.Enable();
    }
    private void OnDisable()
    {
        moveAction.action.Disable();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main.transform;
    }
    
    private void Update()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();//키보드에서 입력 받은 방향

        Vector3 forward = mainCamera.forward;   //현재 카메라가 보는 방향 기준으로 앞
        forward.y = 0f;                         //위로 향하는 방향 제거
        forward.Normalize();

        Vector3 right = mainCamera.right;       //현재 카메라가 보는 방향 기준으로 오른쪽, 왼쪽과 뒤는 마이너스 방향
        right.y = 0f;   
        right.Normalize();

        movement = (forward * moveInput.y + right * moveInput.x).normalized;
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = movement * stat.moveSpeed;
        float currentY = rb.linearVelocity.y;
        rb.linearVelocity = new Vector3(targetVelocity.x, currentY, targetVelocity.z);
    }

    
}
