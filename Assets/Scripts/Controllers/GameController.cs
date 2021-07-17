using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private ImageController imageController;
    [SerializeField] private WordController wordController;
    [SerializeField] private KeyboardController keyboardController;

    [SerializeField] private List<SO_PicsWord> picsAndWords;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI balanceText;

    private int currentLevel = 0;
    private int balance = 100;

    private void OnEnable()
    {
        WordController.Check += OnWins;
    }

    private void OnDisable()
    {
        WordController.Check -= OnWins;
    }

    private void Start()
    {
        SetupLevel(currentLevel);
        balanceText.text = "" + balance;
    }

    public void SetupLevel(int level)
    {
        imageController.SetImage(picsAndWords[level].images);
        wordController.SetWord(picsAndWords[level].word);
        keyboardController.SetKeyboardSymbol(picsAndWords[level].word);
        levelText.text = "" + (currentLevel + 1);
    }

    private void OnWins(bool isWin)
    {
        if (isWin)
        {
            Debug.Log("Is GameController Message: Game Win!");
            currentLevel++;
            if (currentLevel <= picsAndWords.Count - 1)
            {
                SetupLevel(currentLevel);
                ChangeBalance(30);
            }
            else
            {
                Debug.Log("End Level!");
            }
        }
        else
        {
            Debug.Log("Is GameController Message: Game Defeat!");
        }
    }

    public int ChangeBalance(int value)
    {
        if (balance + value < 0)
        {
            return -1;
        }
        else
        {
            balance = balance + value;
            balanceText.text = "" + balance;
            return balance;
        }
    }
}
