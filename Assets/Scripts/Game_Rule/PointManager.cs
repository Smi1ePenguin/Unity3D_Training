using UnityEngine;
using TMPro;
public class PointManager : MonoBehaviour
{
    [Header("캔버스 연결")]
    public TextMeshProUGUI pointText;

    private int point = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            var audioService = AudioServiceLocator.Get<IAudioManager>();
            audioService.PlaySound("Point_Get");

            point++;
            pointText.text = "Points: " + point;
            Destroy(other.gameObject);
        }
    }
}