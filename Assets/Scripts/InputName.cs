using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour
 {
    public InputField inputField;
    
    private string _userName;
    public string userName
    {
        get
        {
            if (_userName == null)
                _userName = PlayerPrefs.GetString("playerName", "agar");
            return _userName;
        }
        set
        {
            _userName = value;
            PlayerPrefs.SetString("playerName", _userName);
        }
    }
    
    public void Awake()
    {
        inputField.text = userName;
    }
    
    public void SetUserName(string text)
    {
        userName = text;
    }
 }
