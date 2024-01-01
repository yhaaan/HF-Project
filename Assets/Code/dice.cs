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
    public Sprite testSprite;
    private UnityEngine.UI.Image image;
    private RectTransform recttTransform;

    // Start is called before the first frame update
    private void Awake()
    {
        isKept = true;
        image = GetComponent<UnityEngine.UI.Image>();
        recttTransform = GetComponent<RectTransform>();
        ChangeN();
    }

    public void ChangeN()
    {
        num = Random.Range(1, 7);
        power = num;
        image.sprite = dices[num];
    }
    
    public void OnClick()
    {
        if(isKept)
        {
            isKept = false;
            recttTransform.rotation = Quaternion.Euler(0,0,45);
        } else if (!isKept)
        {
            isKept = true;
            recttTransform.rotation = Quaternion.Euler(0,0,0);
        }
    }
    void Update()
    {
        
    }
}
