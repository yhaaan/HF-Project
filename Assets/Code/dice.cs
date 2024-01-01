using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public int num;
    public int power;
    public bool isKept;
    public Sprite[] dices;
    private SpriteRenderer sprite;
    private Transform trans;

    // Start is called before the first frame update
    private void Awake()
    {
        isKept = true;
        sprite = GetComponent<SpriteRenderer>();
        trans = GetComponent<Transform>();
        ChangeN();
    }

    public void ChangeN()
    {
        num = Random.Range(1, 7);
        power = num;
        sprite.sprite = dices[num];
    }
    
    public void OnMouseDown()
    {
        if(isKept)
        {
            isKept = false;
            trans.rotation = Quaternion.Euler(0,0,45);
        } else if (!isKept)
        {
            isKept = true;
            trans.rotation = Quaternion.Euler(0,0,0);
        }
    }
    void Update()
    {
        
    }
}
