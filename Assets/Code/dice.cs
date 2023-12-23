using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dice : MonoBehaviour
{
    public int num;
    public int power;
    public Sprite[] diceImg;
    SpriteRenderer spriter;

    // Start is called before the first frame update
    private void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
        ChangeN();
    }

    public void ChangeN()
    {
        num = Random.Range(1, 7);
        power = num;
        spriter.sprite = diceImg[num];
    }
    
    void Update()
    {
        
    }
}
