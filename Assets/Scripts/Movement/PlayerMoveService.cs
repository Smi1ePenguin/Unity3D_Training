using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMoveService : MonoBehaviour
{
    [Header("스크립터블 오브젝트 연결")]
    public BallStat stat;
    [Header("입력 세팅")]
    public InputActionReference moveAction;
    public event Action<Vector3> OnMoveInput;

    private Vector3 movement;
    private Transform mainCamera;
    public float air_time = 0f;

    public void initialize()
    {
        moveAction.action.Enable();
        mainCamera = Camera.main.transform;
    }

    public void end()
    {
        moveAction.action.Disable();
    }

    public void Update()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();

        Vector3 forward = mainCamera.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = mainCamera.right;
        right.y = 0f;
        right.Normalize();

        movement = (forward * moveInput.y + right * moveInput.x).normalized;

        OnMoveInput?.Invoke(movement);
    }
}
