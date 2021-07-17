using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum StatusButton
{
    Default,
    HaveLetter,
    OpenTrueLetter
}

public class ButtonWordField : MonoBehaviour
{
    public StatusButton status;

    private Button button;
    private TextMeshProUGUI textButton;

    public Button WordButton 
    { 
        get { return button; }
    }
    public TextMeshProUGUI WordTextButton { get { return textButton; } }

    private void Awake()
    {
        status = StatusButton.Default;
        button = GetComponent<Button>();
        textButton = GetComponentInChildren<TextMeshProUGUI>();
    }
}
