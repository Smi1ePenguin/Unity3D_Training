using UnityEngine;
using UnityEngine.SceneManagement;
public class Main_Menu_Manager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Round1");
        SceneManager.LoadScene("Round1_BackGround", LoadSceneMode.Additive);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
