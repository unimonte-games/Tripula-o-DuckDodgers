﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public GameObject[] prefabs;
    private GameObject InstantiateBlock(int index)
    {
        var instance = Instantiate(prefabs[index]);
        instance.transform.SetParent(gameObject.transform, false);

        return instance;
    }

    int[,] pieces = new int[,] {
            { 1, 2, 3 },
            { 3, 1, 1 },
            { 2, 3, 1 }
};
    void Start()
    {
        for (int i = 0; i < pieces.GetLength(0); i++)
        {
            for (int j = 0; j < pieces.GetLength(1); j++)
            {
               var obj = InstantiateBlock(pieces[i, j]);
               var color = obj.GetComponent<Image>().color;
               Debug.Log(color);
            }
        }
    }

}