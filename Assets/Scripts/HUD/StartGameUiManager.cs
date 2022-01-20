using System;
using System.Collections;
using System.Collections.Generic;
using HUD;
using Models;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StartGameUiManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private InputField textField;
    [SerializeField] private HudUiManager hudUiManager;

    private void Awake()
    {
        if (ResultsManager.current != null) gameObject.SetActive(false);
    }

    public void OnStartClick()
    {
        gameObject.SetActive(false);
        var result = new UserResult
        {
            UserName = textField.text
        };
        ResultsManager.instance.Add(result);
        hudUiManager.SetUserName(result.UserName);
    }
}