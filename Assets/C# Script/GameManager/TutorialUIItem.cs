using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUIItem : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public Image sprite;
    public void UpdateItem(string txt, Sprite imgSprite)
    {
        sprite.sprite = imgSprite;
        this.txt.text = txt;
    }
}
