using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Design
{
    public class DesignState : MonoBehaviour
    {
        public Color CellColor = Color.red;
        [Range(2, 15)] public byte boardSize = 9;
        public DesignInfo info;

        public GridLayoutGroup board;
        public GridLayoutGroup axisX;
        public GridLayoutGroup axisY;

        public DesignCell cellTemplate;
        public AxisNumber axisXTemplate;
        public AxisNumber axisYTemplate;


        private void Start()
        {
            board.constraintCount = boardSize;
            for (byte i = 1; i <= boardSize; i++)
            {
                var goX = Instantiate(axisXTemplate, axisX.transform);
                var goY = Instantiate(axisYTemplate, axisY.transform);
                goX.number = i;
                goY.number = i;
                for (byte j = 1; j <= boardSize; j++)
                {
                    var go = Instantiate(cellTemplate, board.transform);
                    go.data.SetCoordinate(j, i);
                    go.state = this;
                    go.Reset();
                    go.gameObject.SetActive(true);
                }
                //
                // Texture2D t2;
                // t2.LoadImage();
                // t2.width;
                // t2.height;
                // Sprite.Create(t2, new Rect(0, 0,  t2.width，  t2.height), Vector2.zero);
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