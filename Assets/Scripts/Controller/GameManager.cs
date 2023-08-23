using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

public partial class GameManager : SerializedMonoBehaviour
{
    private static GameManager instance;

    [FoldoutGroup("Persistant Component", false)]
    [SerializeField] private UIManager uiManager;
    [FoldoutGroup("Persistant Component")]
    [SerializeField] private CameraController mainCamera;
    [Title("Addressables")]
    public AddressablesObj addressablesObj;
    [Title("Loading Scene")]
    public LoadingScene loadingScene;

    public event Action GamePaused;
    public event Action GameResumed;
    public event Action playerAction;
    public event Action enemyAction;

    public GameFSM GameStateController { get; private set; }
    public CameraController MainCamera => mainCamera;
    public UIManager UiManager => uiManager;
    public AddressablesObj AddressablesObj => addressablesObj;
    public LoadingScene LoadingScene => loadingScene;

    [Title("State")]
    public PlayerState playerState;
    public EnemyState enemyState;

    [Title("Point Player")]
    [SerializeField] private Vector3 pointPlayer;

    [Space]
    [BoxGroup("Level")]
    [SerializeField] private LevelConstraint levelConstraint;

    [Title("Count Stage Game")]
    [SerializeField]
    private int countStage;
    [SerializeField]
    private int countDownStage = 0;

    private IDataLevel dataLevel;
    public bool IsLevelLoading { get; private set; }
    public ILevelInfo DataLevel => dataLevel;
    public int CurrentLevel => DataLevel.GetCurrentLevel();
    private LevelManager currentLevelManager;

    [SerializeField]
    private int count = 0;

    [SerializeField]
    private int countEnemy = 9;
    public LevelManager LevelManager
    {
        get => currentLevelManager;
        private set => currentLevelManager = value;
    }
    public PlayerDataManager PlayerDataManager => PlayerDataManager.Instance;
    public Profile Profile { get; private set; }
    public static GameManager Instance { get => instance; set => instance = value; }
    public int Count { get => count; set => count = value; }
    public int CountEnemy { get => countEnemy; set => countEnemy = value; }
    public int CountDownStage { get => countDownStage; set => countDownStage = value; }
    public int CountStage { get => countStage; set => countStage = value; }

    [SerializeField]
    private GameObject waveGame;

    int[] bgsToCheck = { 1, 7, 13 };

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        GameStateController = new GameFSM(this);
        Profile = new Profile();

        //DOTween.Init().SetCapacity(200, 125);

        dataLevel = PlayerDataManager.GetDataLevel(levelConstraint);
        dataLevel.LevelConstraint = levelConstraint;
        Debug.Log(dataLevel);
    }

    private void Start()
    {
        //dataLevel.SetLevel(LevelType.Normal, 1);
        playerAction = StateMovePlayer;
        uiManager.Init();
        Time.timeScale = 0f;
        LoadPlayer();
        LoadLevel();
    }

    public void LoadPlayer()
    {
        GameObject obj = Resources.Load<GameObject>(Helper.PathAirResources + PlayerPrefs.GetInt(Helper.IDAIR));
        Instantiate(obj, pointPlayer, Quaternion.identity);
    }

    /// <summary>
    /// Load level mới và xóa level hiện tại
    /// </summary>
    public void LoadLevel()
    {
        countDownStage++;

        GameStateController.ChangeState(GameState.LOBBY);

        if (bgsToCheck.Contains(CurrentLevel))
        {
            GameObject obj = Resources.Load<GameObject>(Helper.PathBGResources + CurrentLevel);
            GameObject bg = Instantiate(obj, gameObject.transform.position, Quaternion.identity);
            bg.transform.parent = gameObject.transform;
        }

        GameObject obj1 = Resources.Load<GameObject>(Helper.PathLevelResources + CurrentLevel);
       // GameObject obj1 = Resources.Load<GameObject>(Helper.PathLevelResources + 1);
        GameObject levelWave = Instantiate(obj1, waveGame.transform.position, Quaternion.identity);
        levelWave.transform.parent = waveGame.transform;
    }


    /// <summary>
    /// Đưa game về state Lobby và khởi tạo lại các giá trị cần thiết cho mỗi level mới.
    /// <remarks>
    /// LevelManager khi đã load xong thì PHẢI gọi hàm này.
    /// </remarks>
    /// </summary>
    /// <param name="levelManager"></param>
    public void RegisterLevelManager(LevelManager levelManager)
    {
        LevelManager = levelManager;
        GameStateController.ChangeState(GameState.LOBBY);
        //uiManager.OpenLoading(false);
        IsLevelLoading = false;
    }

    /// <summary>
    /// Bắt đầu level, đưa game vào state <see cref="GameState.IN_GAME"/>
    /// </summary>
    public void StartLevel()
    {
        //Analytics.LogTapToPlay();
        GameStateController.ChangeState(GameState.IN_GAME);
    }

    /// <summary>
    /// Kết thúc game sau một khoảng thời gian
    /// </summary>
    /// <param name="result"></param>
    /// <param name="delayTime"></param>
    public void DelayedEndgame(LevelResult result, float delayTime = 1.5f)
    {
        StartCoroutine(DelayedEndgameCoroutine(result, delayTime));
    }

    private IEnumerator DelayedEndgameCoroutine(LevelResult result, float delayTime)
    {
        yield return Yielders.Get(delayTime);
        EndLevel(result);
    }

    /// <summary>
    /// Kết thúc game
    /// </summary>
    /// <param name="result"></param>
    public void EndLevel(LevelResult result)
    {
        GameStateController.ChangeState(GameState.END_GAME);
        Debug.Log("OnEnter EndLevel");

        if (result == LevelResult.Win)
        {
            IncreaseLevel();
            Debug.Log(dataLevel);
        }
    }

    /// <summary>
    /// Tăng level
    /// </summary>
    public void IncreaseLevel()
    {
        dataLevel.IncreaseLevel();
    }


    /// <summary>
    /// Hồi sinh
    /// </summary>
    public void Revive()
    {
        loadingScene.LoadScene(1);
        LevelManager.ResetLevelState();
        ResetStatePlayer();
        // TODO: Revive code
    }

    public void NextLevel()
    {
        LevelManager.Instance.ResetLevelState();
        LoadLevel();
        StartLevel();
        ResetStatePlayer();
        // TODO: Revive code
    }

    public void ResetStatePlayer()
    {
        playerState = PlayerState.MOVE;
    }

    public void ResetStateEnemy()
    {
        count = 0;
        enemyState = EnemyState.IDLE;
    }

    public bool CountStageMath()
    {
        if (countDownStage == countStage) return true;
        return false;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        GamePaused?.Invoke();
    }

    public void PlayerAction()
    {
        playerAction?.Invoke();
    }

    private void StateMovePlayer()
    {
        playerState = PlayerState.MOVE;
    }

    public void StateShootingEnemy()
    {
        enemyState = EnemyState.SHOOTING;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        GameResumed?.Invoke();
    }

    public void AddGoldGame(int _coin)
    {
        Profile.AddGold(_coin);
    }

    public int GetGoldGame()
    {
        return Profile.GetGold();
    }

    private void Update()
    {
        if (!IsLevelLoading)
            GameStateController.Update();
    }

    private void FixedUpdate()
    {
        if (!IsLevelLoading)
            GameStateController.FixedUpdate();
    }

    private void LateUpdate()
    {
        if (!IsLevelLoading)
            GameStateController.LateUpdate();
    }
}
