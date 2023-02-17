using System.Collections;
using System.Collections.Generic;
using Design;
using UnityEngine;

public class EditorState : MonoBehaviour
{
    public Color CellColor = Color.red;
    public GridLayout checkerboard;
    public DesignCell template;


    private void Start()
    {
        template.gameObject.SetActive(false);
        for (var i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                var go = Instantiate(template, checkerboard.transform);
                go.name = $"Cell_{i}_{j}";
            }
        }
    }


    private void Update()
    {
    }
}