using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Board : MonoBehaviour
{
    public static Board Instance;
    public GameObject[] prefabs;
    private GameObject InstantiateBlock(int index)
    {
        var instance = Instantiate(prefabs[index]);
        instance.transform.SetParent(gameObject.transform, false);

        return instance;
    }

    public int[,] pieces = new int[,] {
            { 2, 3, 2, 3},
            { 3, 2, 3, 2},
            { 2, 3, 2, 3},
            { 3, 2, 3, 2}
    };
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<Board>();
        }
    }

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

    public bool IsGameOver()
    {
        int Counter = 0;
        foreach (Transform obj in transform)
        {
            if (obj.GetComponent<Piece>().Color > 1)
            {
                Counter++;
            }
        }
        Debug.Log("Counter" + Counter);
        return (Counter == 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.name);
        }
    }
}