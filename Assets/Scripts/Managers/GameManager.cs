using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public enum State
    {
        TITLE,
        GAME,
        GAME_OVER
    }
    

    [SerializeField] ScreenFade screenFade;
    [SerializeField] public AudioClip winMusicClip;
    [SerializeField] public AudioClip loseMusicClip;
    [SerializeField] SceneLoader sceneLoader;
    public GameData gameData;

    public string pOneName { get; set; }
    public string pTwoName { get; set; }
    public bool whosTurn { get; set; } // false = Player One : true = Player Two

    public State state = State.TITLE;

    public override void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        PlayerPrefs.SetFloat("MusicVolume", 0.1f);
        PlayerPrefs.SetFloat("SFXVolume", 0.3f);

        InitScene();

        SceneManager.activeSceneChanged += OnSceneWasLoaded;
    }

    void InitScene()
    {
        SceneDescriptor sceneDescriptor = FindObjectOfType<SceneDescriptor>();
        if (sceneDescriptor != null)
        {
            if(sceneDescriptor.player) Instantiate(sceneDescriptor.player, sceneDescriptor.playerSpawn.position, sceneDescriptor.playerSpawn.rotation);
            if (sceneDescriptor.music) AudioManager.Instance.PlayMusic(sceneDescriptor.music);
        }
    }

    private void Update()
    {
        switch (state)
        {
            case State.TITLE:
                break;
            case State.GAME:
                break;
            case State.GAME_OVER:
                break;
            default:
                break;
        }
    }

    public void OnLoadScene(string sceneName)
    {
        sceneLoader.Load(sceneName);
    }

    void OnSceneWasLoaded(Scene current, Scene next)
    {
        InitScene();
    }
}
