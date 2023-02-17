using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Design
{
    public class DesignCell : MonoBehaviour, IBeginDragHandler, IEndDragHandler
    {
        private EditorState state;
        public Image image;

        private void Awake()
        {
            transform.parent.GetComponent<EditorState>();
        }

        private void Start()
        {
        }

        private void Update()
        {
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            image.color = state.CellColor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
        }
    }
}