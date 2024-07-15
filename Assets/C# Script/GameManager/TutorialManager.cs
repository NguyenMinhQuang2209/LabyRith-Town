using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;
    public TutorialUIItem uiItem;
    public GameObject uiContainer;
    public Transform uiContent;
    [SerializeField] private bool currentStatus = true;
    public List<Tutorial_Item> tutorial_Items = new List<Tutorial_Item>();
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        foreach (Transform child in uiContent.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Tutorial_Item item in tutorial_Items)
        {
            TutorialUIItem currentItem = Instantiate(uiItem, uiContent.transform, false);
            currentItem.UpdateItem(item.txt, item.sprite);
        }
        uiContainer.SetActive(currentStatus);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentStatus = !currentStatus;
            uiContainer.SetActive(currentStatus);
        }
    }
}
[System.Serializable]
public class Tutorial_Item
{
    public string txt;
    public Sprite sprite;
}