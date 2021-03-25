using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorMarker : MonoBehaviour
{
    [SerializeField]
    private ColorSettingButton button;
    private Color color;

    private void Awake()
    {
        color = GetComponent<Image>().color;
    }

    public void SendColor()
    {
        button.ChangeButtonColor(color);
    }
}
