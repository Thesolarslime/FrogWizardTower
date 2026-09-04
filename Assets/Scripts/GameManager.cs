using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    
    [SerializeField] GameObject BackGround;

    public float BackgroundSpawnTimer = 0;
    
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
    }

    // Update is called once per frame
    void Update()
    {
        BackgroundSpawnTimer += Time.deltaTime;

        if (BackgroundSpawnTimer > 10)
        {
            RandomSpawn = Random.Range(45, 70);
            Instantiate(BackGround, BackGroundSpawnLocation, Quaternion.identity);
            BackgroundSpawnTimer = 0;
        }

    }
}
