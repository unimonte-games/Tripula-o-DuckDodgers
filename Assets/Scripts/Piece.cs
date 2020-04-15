using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
    public int Color;
    public Sprite[] Colors;
    public bool Black;

    private void Start()
    {
        UpdateColor();
    }

    public void UpdateColor()
    {
        var selectedColor = Colors[Color];
        GetComponent<Image>().sprite = selectedColor;
    }
}
