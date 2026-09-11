using TMPro;
using Unity.Hierarchy;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public static GameManager instance { get; private set; }
    
    [SerializeField] GameObject BackGround;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject LevelUpParicle;
    public float HigerSpawnRange = 10f;
    public float LowerSpawnRange = 5f;

    public float BackgroundSpawnTimer = 0;

    private float GameTimer = 0;
    private int GameTimerInt = 0;
    private float ElapsedTimeForLevel = 0;
    public float LevelUpTime = 30;
    public int Level = 0;
    

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
        BackgroundSpawnTimer += Time.deltaTime;
        if (BackgroundSpawnTimer > 10)
        {
            RandomSpawn = Random.Range(45, 70);
            Instantiate(BackGround, BackGroundSpawnLocation, Quaternion.identity);
            BackgroundSpawnTimer = 0;
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
