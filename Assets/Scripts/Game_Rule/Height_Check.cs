using UnityEngine;
using TMPro;

public class Height_Check : MonoBehaviour
{
    [Header("연결할 오브젝트")]
    public Transform player;
    public TextMeshProUGUI hightText;

    private void Update()
    {
        float currentHeight = player.position.y - 1.2f;
        hightText.text = "Height: " + currentHeight.ToString("F1") + "m";
    }
}
