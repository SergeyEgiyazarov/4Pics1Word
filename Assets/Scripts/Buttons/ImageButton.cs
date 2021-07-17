using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageButton : MonoBehaviour
{
    public GameObject[] othersImage;

    private Button button;
    private Animator animator;
    private bool isOpen;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        button = GetComponent<Button>();
        
        button.onClick.AddListener(PlayAnimation);
        isOpen = false;
    }

    private void PlayAnimation()
    {
        isOpen = isOpen ? false : true;
        for (int i = 0; i < othersImage.Length; i++)
        {
            othersImage[i].SetActive(!isOpen);
        }
        animator.SetBool("IsOpen", isOpen);
        
    }
}
