using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Text : MonoBehaviour
{
    public TMP_Text UIText;
    private float timer;
    
    void Start()
    {
        timer = 0.0f;
    }

    void Update()
    {
        timer += Time.deltaTime * 2;
        if ( timer % 2 > 1.0f )
        {
            UIText.text = "";
        }
        else
        {
            UIText.text = "Press any key to play";
        }
    }
}
