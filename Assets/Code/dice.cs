
using UnityEngine;


/*
 * Desc :: 주사위
 */
public class Dice : MonoBehaviour
{
    public int num; //주사위의 눈금
    public bool isKept = false;
    public Sprite[] diceImages;
    private SpriteRenderer diceSprite;


    private void Awake()
    {
        isKept = false;
        diceSprite = GetComponent<SpriteRenderer>();

    }

    public void Roll()
    {
        num = Random.Range(1, 7);
        diceSprite.sprite = diceImages[num];
    }
    
    public void OnMouseDown()
    {
        ToggleKeptStatus();
    }

    public void ToggleKeptStatus()
    {
        if(isKept)
        {
            isKept = false;
            transform.rotation = Quaternion.Euler(0,0,0);
        } else if (!isKept)
        {
            isKept = true;
            transform.rotation = Quaternion.Euler(0,0,45);
        }
    }
}
