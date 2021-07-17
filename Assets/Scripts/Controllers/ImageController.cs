using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    [SerializeField] private List<Image> images;

    public void SetImage(List<Sprite> inImages)
    {
        for (int i = 0; i < inImages.Count; i++)
        {
            images[i].sprite = inImages[i];
        }
    }
}
