using UnityEngine;
using System;
using Unity.VisualScripting;
public class PlayerMove : MonoBehaviour
{
    [Header("스크립터블 오브젝트 연결")]
    public BallStat stat;

    private Rigidbody rb;
    private Vector3 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        movement = new Vector3(moveX, 0, moveZ).normalized;
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = movement * stat.moveSpeed;
        float currentY = rb.linearVelocity.y;
        rb.linearVelocity = new Vector3(targetVelocity.x, currentY, targetVelocity.z);
    }

}
