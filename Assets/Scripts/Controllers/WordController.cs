using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordController : MonoBehaviour
{
    public delegate void Validation(bool isWin);
    public static event Validation Check;

    public ButtonWordField[] buttonsWordField;

    private KeyboardController keyboardController;

    private string trueWord;
    private string testWord;
    private int activeLetterIndex;

    private void Awake()
    {
        keyboardController = FindObjectOfType<KeyboardController>();
    }

    public void SetWord(string word)
    {
        trueWord = word;
        testWord = "";
        activeLetterIndex = 0;

        for (int i = 0; i < trueWord.Length; i++)
        {
            buttonsWordField[i].gameObject.SetActive(true);
            buttonsWordField[i].status = StatusButton.Default;
            buttonsWordField[i].WordButton.interactable = false;

            buttonsWordField[i].WordTextButton.text = "";
            testWord = testWord + " ";
        }
    }

    public void SetLetter(char letter)
    {
        if (activeLetterIndex < trueWord.Length && buttonsWordField[activeLetterIndex].WordTextButton.text == "")
        {
            buttonsWordField[activeLetterIndex].WordButton.interactable = true;
            buttonsWordField[activeLetterIndex].WordTextButton.text = "" + letter;
            buttonsWordField[activeLetterIndex].status = StatusButton.HaveLetter;
            testWord = ChangeSymbol(activeLetterIndex, letter);
            activeLetterIndex++;
        }
        else
        {
            activeLetterIndex++;
            SetLetter(letter);
        }

        CheckWord();
    }

    private void CheckWord()
    {
        for (int i = 0; i < testWord.Length; i++)
        {
            if (char.IsWhiteSpace(testWord[i]))
            {
                return;
            }
        }

        if (testWord.ToLower() == trueWord.ToLower())
        {
            activeLetterIndex = 0;
            DeactivationWord();
            Check(true);
            Debug.Log("Win!");
        }
        else
        {
            Check(false);
            Debug.Log("Dafeat!");
        }
    }

    private string ChangeSymbol(int index, char letter)
    {
        char[] array = testWord.ToCharArray();
        array[index] = letter;
        string outString = new string(array);
        return outString;
    }

    public void DeletSymbol(int index)
    {
        buttonsWordField[index].WordButton.interactable = false;
        buttonsWordField[index].status = StatusButton.Default;

        keyboardController.ReturnButton(buttonsWordField[index].WordTextButton.text);
        buttonsWordField[index].WordTextButton.text = "";
        if (index < activeLetterIndex)
        {
            activeLetterIndex = index;
        }
    }

    public void ReturnAllSymbol()
    {
        for (int i = 0; i < trueWord.Length; i++)
        {
            if (buttonsWordField[i].WordButton.interactable == true && buttonsWordField[i].status != StatusButton.OpenTrueLetter)
            {
                DeletSymbol(i);
            }
        }
    }

    private void DeactivationWord()
    {
        for (int i = 0; i < buttonsWordField.Length; i++)
        {
            buttonsWordField[i].gameObject.SetActive(false);
        }
    }

    public void OpenLetter()
    {
        ReturnAllSymbol();

        int randomIndex = Random.Range(0, trueWord.Length);

        while (buttonsWordField[randomIndex].status == StatusButton.OpenTrueLetter)
        {
            randomIndex = Random.Range(0, trueWord.Length);
        }

        buttonsWordField[randomIndex].WordTextButton.text = "" + trueWord[randomIndex];
        buttonsWordField[randomIndex].status = StatusButton.OpenTrueLetter;


        keyboardController.DeletOpenLetter(buttonsWordField[randomIndex].WordTextButton.text);
    }
}
