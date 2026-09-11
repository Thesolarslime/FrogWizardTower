using TMPro;
using Unity.Hierarchy;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public static GameManager instance { get; private set; }
    [Header("Reffrences")]
    [SerializeField] GameObject BackGround;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject LevelUpParicle;
    [Header("Mobs")]
    public float HigerSpawnRange = 10f;
    public float LowerSpawnRange = 5f;
    [Header("Game State")]
    public float LevelUpTime = 30;
    public float CloudSpawnTimer = 10;


    private float GameTimer = 0;
    private int GameTimerInt = 0;
    private float ElapsedTimeForLevel = 0;
    private float ElapsedTimeForClouds = 0;

    private void Awake()
    {
        // if there is a version of this which isnt this, delete this 
        if (instance != null && instance != this)
        { 
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    Vector3 BackGroundSpawnLocation;
    int RandomSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RandomSpawn = Random.Range(50, 70);

        BackGroundSpawnLocation = new Vector3(RandomSpawn, 6.4f, 0);
        Instantiate(BackGround, BackGroundSpawnLocation, Quaternion.identity);
    }

    public float SpawnTimeRandomiser()
    {
        float SpawnTime;
       return SpawnTime = Random.Range(LowerSpawnRange, HigerSpawnRange);
    }

    public void LevelUp()
    {
        print("levelUp");
        Instantiate(LevelUpParicle, Player.transform.position, Quaternion.identity);
    }

    private void LevelUpSystem()
    {
        ElapsedTimeForLevel += Time.deltaTime;

        if(ElapsedTimeForLevel >= LevelUpTime)
        {
            LevelUp();
            ElapsedTimeForLevel = 0;
        }
    }

    private void CloudSpawning()
    {
        ElapsedTimeForClouds += Time.deltaTime;
        if (ElapsedTimeForClouds > CloudSpawnTimer)
        {
            RandomSpawn = Random.Range(45, 70);
            Instantiate(BackGround, BackGroundSpawnLocation, Quaternion.identity);
            ElapsedTimeForClouds = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameTimer += Time.deltaTime;

        GameTimerInt = Mathf.RoundToInt(GameTimer);
        TimerText.text = GameTimerInt.ToString();

        LevelUpSystem();
        
        CloudSpawning();
    }
}
