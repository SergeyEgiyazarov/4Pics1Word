using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PicsAndWord", menuName = "SO/SO_PicsWord")]
public class SO_PicsWord : ScriptableObject
{
    public List<Sprite> images;
    public string word;
}
