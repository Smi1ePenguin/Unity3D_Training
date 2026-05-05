using UnityEngine;
using UnityEngine.InputSystem;
public class GameManager : MonoBehaviour
{
    [Header("옵션 패널 연결")]
    public GameObject optionPanel;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame && optionPanel.activeSelf)
        {
            optionPanel.SetActive(false);
            Time.timeScale = 1f;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if(Keyboard.current.escapeKey.wasPressedThisFrame && !optionPanel.activeSelf)
        {
            optionPanel.SetActive(true);
            Time.timeScale = 0f;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
