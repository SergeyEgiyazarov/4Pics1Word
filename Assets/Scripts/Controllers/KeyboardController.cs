using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardController : MonoBehaviour
{
    public GameObject[] buttonKeyboard;
    public ButtonKeyboard[] buttonsKeyboard;

    private WordController wordController;

    private string symbols = "אבגדהוזחטיךכלםמןנסעףפץקרשתûü‎‏ÿ";
    private int letterCount;
    private string trueWord;

    private void Awake()
    {
        wordController = FindObjectOfType<WordController>();
        letterCount = buttonsKeyboard.Length;
    }

    private char GetRandomSymbols()
    {
        int ranbomIndex = Random.Range(0, symbols.Length);

        return symbols[ranbomIndex];
    }

    public void SetKeyboardSymbol(string word)
    {
        trueWord = word;


        for (int i = word.Length; i < letterCount; i++)
        {
            word = word + GetRandomSymbols();
        }

        char[] arrayChar = word.ToCharArray();
        for (int i = 0; i < arrayChar.Length; i++)
        {
            int k = Random.Range(0, arrayChar.Length);
            char tmp = arrayChar[k];
            arrayChar[k] = arrayChar[i];
            arrayChar[i] = tmp;
        }

        for (int i = 0; i < letterCount; i++)
        {
            /*TextMeshProUGUI textButton = buttonKeyboard[i].GetComponentInChildren<TextMeshProUGUI>();
            Button button = buttonKeyboard[i].GetComponent<Button>();
            button.interactable = true;
            textButton.text = "" + arrayChar[i];*/

            buttonsKeyboard[i].KeyboardButton.interactable = true;
            buttonsKeyboard[i].status = KeyboardStatus.Active;

            buttonsKeyboard[i].TextKeyboardButton.text = "" + arrayChar[i];
        }
    }

    public void ClickLetter(ButtonKeyboard buttonKeyboard)
    {
        /*TextMeshProUGUI textButton = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
        Button button = buttonObject.GetComponent<Button>();
        button.interactable = false;
        wordController.SetLetter(textButton.text[0]);*/

        buttonKeyboard.KeyboardButton.interactable = false;
        buttonKeyboard.status = KeyboardStatus.NonActive;

        wordController.SetLetter(buttonKeyboard.TextKeyboardButton.text[0]);
    }

    public void ReturnButton(string str)
    {
        for (int i = 0; i < letterCount; i++)
        {
            /*TextMeshProUGUI textButton = buttonKeyboard[i].GetComponentInChildren<TextMeshProUGUI>();
            Button button = buttonKeyboard[i].GetComponent<Button>();

            if (textButton.text == str && button.interactable == false)
            {
                button.interactable = true;
                break;
            }*/

            if (buttonsKeyboard[i].TextKeyboardButton.text == str && buttonsKeyboard[i].KeyboardButton.interactable == false)
            {
                buttonsKeyboard[i].KeyboardButton.interactable = true;
                buttonsKeyboard[i].status = KeyboardStatus.Active;
                break;
            }
        }
    }

    public void RemoveLetters()
    {
        for (int i = 0; i < trueWord.Length; i++)
        {
            for (int k = 0; k < buttonsKeyboard.Length; k++)
            {
                if (buttonsKeyboard[k].TextKeyboardButton.text[0] == trueWord[i] && buttonsKeyboard[k].status != KeyboardStatus.NotRemove)
                {
                    buttonsKeyboard[k].status = KeyboardStatus.NotRemove;
                    break;
                }
            }
        }

        for (int i = 0; i < buttonsKeyboard.Length; i++)
        {
            if (buttonsKeyboard[i].status != KeyboardStatus.NotRemove)
            {
                DeletButton(buttonsKeyboard[i]);
            }
        }
    }

    private void DeletButton(ButtonKeyboard buttonKeyboard)
    {
        buttonKeyboard.KeyboardButton.interactable = false;
        buttonKeyboard.TextKeyboardButton.text = "";
        buttonKeyboard.status = KeyboardStatus.Deleted;
    }

    public void DeletOpenLetter(string str)
    {
        for (int i = 0; i < buttonsKeyboard.Length; i++)
        {
            if (buttonsKeyboard[i].TextKeyboardButton.text == str)
            {
                DeletButton(buttonsKeyboard[i]);
                break;
            }
        }
    }
}
