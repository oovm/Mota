using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Design
{
    public class DesignCell : MonoBehaviour,
        IBeginDragHandler, IEndDragHandler,
        IPointerClickHandler, IScrollHandler,
        IPointerEnterHandler, IPointerExitHandler
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

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("DesignCell.OnBeginDrag()");
            image.color = state.CellColor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("DesignCell.OnEndDrag()");
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            state.ShowCellInfo(data);
        }

        public void OnScroll(PointerEventData eventData)
        {
            state.ScrollFloor(eventData.scrollDelta.y);
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            hover.gameObject.SetActive(true);
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