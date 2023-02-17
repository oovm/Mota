using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Design
{
    public class DesignCell : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IPointerClickHandler,
        IPointerEnterHandler, IPointerExitHandler
    {
        public int coordinateX;
        public int coordinateY;
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
            Debug.Log("DesignCell.OnPointerClick()");
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
            hover.gameObject.SetActive(false);
        }
    }
}