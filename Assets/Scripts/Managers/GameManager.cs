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
        PLAYER_START,
        GAME,
        PLAYER_DEAD,
        GAME_OVER,
        GAME_WIN,
        GAME_WAIT
    }

    [SerializeField] ScreenFade screenFade;
    [SerializeField] public AudioClip winMusicClip;
    [SerializeField] public AudioClip loseMusicClip;
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject loseUI;
    public int scoreToWin;
    public GameData gameData;

    public State state = State.TITLE;
    int highScore;

    public override void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            gameData.intData["Lives"] = 3;
        }
        else
        {
            Destroy(gameObject);
        }
        gameData.intData["Score"] = 0;
        //highScore = PlayerPrefs.GetInt("highscore", 0);
        //highScore++;
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
            case State.PLAYER_START:
                break;
            case State.GAME:
                break;
            case State.PLAYER_DEAD:
                break;
            case State.GAME_OVER:
                break;
            case State.GAME_WIN:
                break;
            case State.GAME_WAIT:
                break;
            default:
                break;
        }
    }

    public void OnLoadScene(string sceneName)
    {
        sceneLoader.Load(sceneName);
    }

    public void OnPlayerDead()
    {
        gameData.intData["Lives"]--;

        if (gameData.intData["Lives"] <= 0)
        {
            //OnLoadScene("MainMenu");
            state = State.GAME_OVER;
        }
        else
        {
            OnLoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnSceneWasLoaded(Scene current, Scene next)
    {
        InitScene();
    }
}
