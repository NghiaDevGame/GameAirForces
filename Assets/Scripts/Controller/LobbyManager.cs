using Sirenix.OdinInspector;
using UnityEngine;

public partial class LobbyManager : SerializedMonoBehaviour
{

    private static LobbyManager instance;

    [SerializeField] private new Camera camera;
    [SerializeField] private UIMainLobby uiMainLobby;

    [Title("Addressables")]
    public AddressablesObj addressablesObj;

    public static LobbyManager Ins { get => instance; set => instance = value; }
    public UIMainLobby UIMainLobby => uiMainLobby;

    public AddressablesObj AddressablesObj => addressablesObj;

    [Space]
    [BoxGroup("Level")]
    [SerializeField] private LevelConstraint levelConstraint;

    private IDataLevel dataLevel;
    public ILevelInfo DataLevel => dataLevel;
    public int CurrentLevel => DataLevel.GetCurrentLevel();
    private LevelManager currentLevelManager;
    public LevelManager LevelManager
    {
        get => currentLevelManager;
        private set => currentLevelManager = value;
    }
    public PlayerDataManager PlayerDataManager => PlayerDataManager.Instance;
    public Profile Profile { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Profile = new Profile();

        dataLevel = PlayerDataManager.GetDataLevel(levelConstraint);
        dataLevel.LevelConstraint = levelConstraint;
        Debug.Log(dataLevel);
    }

    private void Start()
    {
        //AddGoldGame(200);
    }

    public void AddGoldGame(int goldBonus)
    {
        int _count = GetGoldGame() + goldBonus;
        PlayerDataManager.Instance.SetGold(_count);
    }

    public void ReloadGoldGame()
    {
        PlayerDataManager.Instance.SetGold(8000);
    }

    public int GetGoldGame()
    {
        return PlayerDataManager.Instance.GetGold();
    }

    public void DeductGoldGame(int goldBonus)
    {
        int _count = 0;
        if (GetGoldGame() >= 0)
        {
            _count = GetGoldGame() - goldBonus;
        }
        PlayerDataManager.Instance.SetGold(_count);
    }

    public void IdEquipmentGamePlay(int id)
    {
        PlayerPrefs.SetInt(Helper.IDEQUIPMENT, id);
    }

/*    public void IDTrainGamePlay(int id)
    {
        if(id != 0)
        {
            PlayerPrefs.SetInt(Helper.IDTRAIN, id);
        }
        PlayerPrefs.SetInt(Helper.IDTRAIN, 0);
    }*/

    public void IDTrainGamePlay(int id)
    {
        if (GetIDAir() < 4)
        {
            int _count = GetIDAir() + id;
            SetIDAir(_count);
        }
    }

    public void SetIDAir(int id)
    {
        PlayerPrefs.SetInt(Helper.IDAIR, id);
    }

    public int GetIDAir()
    {
        return PlayerPrefs.GetInt(Helper.IDAIR);
    }

}
