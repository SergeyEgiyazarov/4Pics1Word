using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum KeyboardStatus
{
    Active,
    NonActive,
    NotRemove,
    Deleted
}

public class ButtonKeyboard : MonoBehaviour
{
    public KeyboardStatus status;

    private Button button;
    private TextMeshProUGUI textButton;

    public Button KeyboardButton
    {
        get { return button; }
    }

    public TextMeshProUGUI TextKeyboardButton
    {
        get { return textButton; }
    }

    private void Awake()
    {
        status = KeyboardStatus.Active;
        button = GetComponent<Button>();
        textButton = GetComponentInChildren<TextMeshProUGUI>();
    }
}
