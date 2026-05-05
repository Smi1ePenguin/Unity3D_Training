using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class Option_Panel_Manager : MonoBehaviour
{
    [Header("오디오 믹서 연결")]
    public AudioMixer mainMixer;

    public void SetMasterVolume(float volume)
    {
        mainMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void SetBGMVolume(float volume)
    {
        mainMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        mainMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }

    public void LowLoading(bool isOn)
    {
        if(!isOn) SceneManager.UnloadSceneAsync("Round1_BackGround");
        else SceneManager.LoadScene("Round1_BackGround", LoadSceneMode.Additive);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}