using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Design
{
    public class DesignCell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public DesignCellData data;
        public DesignState state;
        public Image image;
        public Image hover;

        private void Start()
        {
            Reset();
        }

        private void Update()
        {
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            var pointer = InputSystem.GetDevice<Mouse>();
            if (pointer.leftButton.isPressed)
            {
                image.color = state.CellColor;
            }
            else if (pointer.rightButton.isPressed)
            {
                image.color = Color.white;
            }

            state.ShowCellInfo(data);
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            hover.gameObject.SetActive(true);

            // use input system
            var pointer = InputSystem.GetDevice<Mouse>();
            if (pointer.leftButton.isPressed)
            {
                image.color = state.CellColor;
            }
            else if (pointer.rightButton.isPressed)
            {
                image.color = Color.white;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            hover.gameObject.SetActive(false);
        }

        public void Reset()
        {
            name = data.GetName();
            hover.gameObject.SetActive(false);
        }
    }

    [Serializable]
    public struct DesignCellData
    {
        public byte coordinateX;
        public byte coordinateY;

        public void SetCoordinate(byte x, byte y)
        {
            coordinateX = x;
            coordinateY = y;
        }

        public string GetName()
        {
            return $"Cell_{coordinateX}_{coordinateY}";
        }
    }
}