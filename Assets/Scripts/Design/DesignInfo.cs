using System.Collections;
using System.Collections.Generic;
using Design;
using TMPro;
using UnityEngine;

public class DesignInfo : MonoBehaviour
{
    public TextMeshProUGUI coordinate;

    public void ShowCellInfo(DesignCellData data)
    {
        coordinate.text = $"坐标: {data.coordinateX}, {data.coordinateY}";
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}