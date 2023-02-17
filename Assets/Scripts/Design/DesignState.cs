using UnityEngine;
using UnityEngine.UI;

namespace Design
{
    public class DesignState : MonoBehaviour
    {
        public Color CellColor = Color.red;
        private const byte boardSize = 13;
        public GridLayoutGroup checkerboard;
        public DesignCell template;
        public DesignInfo info;


        private void Start()
        {
            template.gameObject.SetActive(false);
            for (byte i = 1; i <= boardSize; i++)
            {
                for (byte j = 1; j <= boardSize; j++)
                {
                    var go = Instantiate(template, checkerboard.transform);
                    go.data.SetCoordinate(j, i);
                    go.state = this;
                    go.Reset();
                    go.gameObject.SetActive(true);
                }
            }
        }

        private void Update()
        {
        }

        public void ShowCellInfo(DesignCellData data)
        {
            info.ShowCellInfo(data);
        }

        public void ScrollFloor(float deltaY)
        {
            Debug.Log(deltaY);
        }
    }
}