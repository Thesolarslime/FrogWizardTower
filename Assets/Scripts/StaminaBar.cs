using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] SpriteRenderer BarSprite;
    [SerializeField] PlayerMovment PlayerMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BarSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        BarSprite.size = new Vector2(PlayerMove.Stamina / 8f, 0.3f);
    }
}
