using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;
    public TextMeshProUGUI keyboardTxt;
    public Image bgImage;
    public Image keyboardImage;
    private int current = 0;
    public Button nextBtn;
    public Button prevBtn;
    [TextArea] public TextMeshProUGUI plotTxt;
    public List<TutorialItem> items = new List<TutorialItem>();
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        nextBtn.onClick.AddListener(() =>
        {
            Next();
        });
        prevBtn.onClick.AddListener(() =>
        {
            Previous();
        });
        Show();
    }
    public void Next()
    {
        current = Mathf.Min(items.Count - 1, current + 1);
        Show();
    }
    public void Previous()
    {
        current = Mathf.Max(0, current - 1);
        Show();
    }
    public void Show()
    {
        TutorialItem item = items[current];
        keyboardTxt.text = item.keyboardString;
        plotTxt.text = item.plotString;
        bgImage.sprite = item.bgSprite;
        keyboardImage.sprite = item.keyboardSprite;
        keyboardImage.rectTransform.sizeDelta = item.keyboardSize;
        keyboardImage.gameObject.SetActive(item.keyboardSprite != null);
        bgImage.gameObject.SetActive(item.bgSprite != null);
    }
}
[System.Serializable]
public class TutorialItem
{
    public Sprite bgSprite;
    public string keyboardString;
    public Sprite keyboardSprite;
    public Vector2 keyboardSize = new Vector2();
    public string plotString;
}