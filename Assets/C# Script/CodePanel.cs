using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Text codeText;
    string codeTextValue = "";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        codeText.text = codeTextValue;
        if(codeTextValue == "1306")
        {
            OpenChest.isSafeOpened = true;
        }
        if(codeTextValue.Length == 4 )
        {
            codeTextValue = "";
        }
    }
    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
}
