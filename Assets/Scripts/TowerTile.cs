using UnityEngine;

public class TowerTile : MonoBehaviour
{
    public Sprite[] TileSprites;
    public SpriteRenderer TileSprite;
    private Health TileHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TileHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TileHealth.HP > TileHealth.MaxHP / 1.5f)
        {
            TileSprite.sprite = TileSprites[0];
        }
        else if (TileHealth.HP > TileHealth.MaxHP / 3f)
        {
            TileSprite.sprite = TileSprites[1];
        }
        else
        {
            TileSprite.sprite = TileSprites[2];
        }
    }
}
