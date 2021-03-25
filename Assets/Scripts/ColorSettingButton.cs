using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSettingButton : MonoBehaviour
{
    private Color color;
    private void Awake()
    {
        if (ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString("ColorKey"), out color))
            GetComponent<Image>().color = color;
    }
    public void ChangeButtonColor(Color color)
    {
        GetComponent<Image>().color = color;
    }

    public void OnDestroy()
    {
        PlayerPrefs.SetString("ColorKey", ColorUtility.ToHtmlStringRGBA(GetComponent<Image>().color));
    }
}
