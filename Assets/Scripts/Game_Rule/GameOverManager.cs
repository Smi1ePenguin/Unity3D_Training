using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class GameOverManager : MonoBehaviour
{
    public PlayerMoveService playermoveservice;

    [Header("Game Over Settings")]
    public GameObject gameOverPanel;
    public GameObject clearPanel;
    public GameObject clearTrophy;
    public void OnCollisionEnter(Collision collision)
    {
        if(playermoveservice.air_time > 2.5f || playermoveservice.stat.ball_bounced >= playermoveservice.stat.max_bounce)
        {
            StartCoroutine(GameOver());
        }

        if(collision.gameObject.CompareTag("Finish"))
        {
            StartCoroutine(Clear());    
        }
    }

    private IEnumerator GameOver()
    {
        Time.timeScale = 0f;
        
        var audioService = AudioServiceLocator.Get<IAudioManager>();
        audioService.PlaySound("Game_Over");
        
        gameOverPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(4f);

        Time.timeScale = 1f;

        SceneManager.LoadScene("Round1");
        SceneManager.LoadScene("Round1_BackGround", LoadSceneMode.Additive);
    }

    private IEnumerator Clear()
    {
        clearPanel.SetActive(true);
        clearTrophy.SetActive(false);

        yield return new WaitForSeconds(4f);   

        clearPanel.SetActive(false);
    }
}