using UnityEngine;
using System.Collections.Generic;
//======================================================================================================================================================
public interface IAudioManager
{
    void PlaySound(string soundName);
    void PlayBGM(string soundName);
}
//======================================================================================================================================================
public class AudioManager : MonoBehaviour, IAudioManager
{
    //======================================================================================================================================================
    [System.Serializable]
    public class SoundData      // 사운드 데이터 클래스
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)] public float volume = 0.5f;
    }
    //======================================================================================================================================================
    [Header("효과음 파일 딕셔너리")]
    public SoundData[] soundDataArray;       //효과음들을 SoundData 형식의 배열로 저장
    private Dictionary<string, SoundData> soundDictionary = new Dictionary<string, SoundData>();
    private AudioSource audioSource;         //효과음 전용 audioSource 컴포넌트
    
    [Header("배경음 파일 딕셔너리")]
    public SoundData[] bgmDataArray;            //배경음들을 SoundData 형식의 배열로 저장
    private Dictionary<string, SoundData> bgmDictionary = new Dictionary<string, SoundData>();
    private AudioSource bgmAudioSource;        //배경음 전용 audioSource 컴포넌트

    private string currentBGMName = "";              //현재 재생 중인 배경음 이름
    //======================================================================================================================================================
    private void Awake()
    {
        AudioServiceLocator.Register<IAudioManager>(this);      //서비스 로케이터에 할당

        audioSource = gameObject.AddComponent<AudioSource>();   //audioSource 컴포넌트 추가
        foreach(var sound in soundDataArray)                    //딕셔너리에 추가
        {
            soundDictionary.Add(sound.name, sound);
        }

        bgmAudioSource = gameObject.AddComponent<AudioSource>();    //배경음 전용 audioSource 컴포넌트 추가
        bgmAudioSource.loop = true;                                 //배경음은 반복 재생
        foreach(var bgm in bgmDataArray)                            //딕셔너리에 추가
        {
            bgmDictionary.Add(bgm.name, bgm);
        }
    }
    private void Start()
    {
        var city_ambience_bgm = AudioServiceLocator.Get<IAudioManager>();
        city_ambience_bgm?.PlayBGM("city_ambience");                         //게임 시작 시 배경음 재생
    }
    private void Update()
    {
        bgmAudioSource.volume = bgmDictionary[currentBGMName].volume;
    }
    //======================================================================================================================================================
    public void PlaySound(string soundName)
    {
        if (soundDictionary.ContainsKey(soundName))
        {
            audioSource.pitch = Random.Range(0.6f, 0.9f);
            audioSource.PlayOneShot(soundDictionary[soundName].clip, soundDictionary[soundName].volume);
        }
    }

    public void PlayBGM(string soundName)
    {
        if (bgmDictionary.ContainsKey(soundName))
        {
            if(bgmDictionary[soundName].clip == bgmAudioSource.clip) return;    //이미 재생 중이면 무시

            currentBGMName = soundName;
            bgmAudioSource.clip = bgmDictionary[soundName].clip;
            bgmAudioSource.Play();
        }
    }
}
