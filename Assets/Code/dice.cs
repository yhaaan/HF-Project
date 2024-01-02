using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

/*
 * Desc :: ������ �ֻ��� ����
 * �ֻ����� Sprite�� Mouse �̺�Ʈ ���� ó�� 
 */
public class Dice : MonoBehaviour
{
    public int num;
    public int power;
    public bool isKept;
    public Sprite[] diceImage;
    private SpriteRenderer sprite;
    private Transform trans;

    private void Awake()
    {
        isKept = false;
        sprite = GetComponent<SpriteRenderer>();
        trans = GetComponent<Transform>();
        ChangeN();
    }

    public void ChangeN()
    {
        num = Random.Range(1, 7);
        power = num;
        sprite.sprite = diceImage[num];
    }
    
    public void OnMouseDown()
    {
        if(isKept)
        {
            isKept = false;
            trans.rotation = Quaternion.Euler(0,0,0);
        } else if (!isKept)
        {
            isKept = true;
            trans.rotation = Quaternion.Euler(0,0,45);
        }
    }
    void Update()
    {
        
    }
}
