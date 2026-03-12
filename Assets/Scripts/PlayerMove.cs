using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Unity.VisualScripting;
public class PlayerMove : MonoBehaviour
{
    [Header("스크립터블 오브젝트 연결")]
    public BallStat stat;
    [Header("입력 세팅")]
    public InputActionReference moveAction;

    private Rigidbody rb;
    private Vector3 movement;

    private void OnEnable()
    {
        moveAction.action.Enable();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        movement = new Vector3(moveInput.x, 0, moveInput.y).normalized;
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = movement * stat.moveSpeed;
        float currentY = rb.linearVelocity.y;
        rb.linearVelocity = new Vector3(targetVelocity.x, currentY, targetVelocity.z);
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }
}
