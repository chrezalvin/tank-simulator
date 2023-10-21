using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextUI : MonoBehaviour
{
    public TMP_Text tmpText;

    public void ChangeText(string text)
    {
        tmpText.SetText(text);
    }
}
