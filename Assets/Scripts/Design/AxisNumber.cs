using System;
using TMPro;
using UnityEngine;

namespace Design
{
    public class AxisNumber : MonoBehaviour
    {
        private TextMeshProUGUI text;

        public byte number
        {
            set { text.text = value.ToString(); }
        }

        private void Awake()
        {
            text = transform.Find("text").GetComponent<TextMeshProUGUI>();
        }
    }
}