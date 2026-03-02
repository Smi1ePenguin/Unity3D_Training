using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("효과 설정")]
    public AudioClip jumpSound;

    private AudioSource audioSource;
    
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {

    }
    private void OnDisable()
    {
        
    }

    
    
}
