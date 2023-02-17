using UnityEngine;
using UnityEngine.UI;

namespace Design
{
    public class DesignState : MonoBehaviour
    {
        public Color CellColor = Color.red;
        public GridLayoutGroup checkerboard;
        public DesignCell template;


        private void Start()
        {
            template.gameObject.SetActive(false);
            for (var i = 1; i <= 5; i++)
            {
                for (var j = 1; j <= 5; j++)
                {
                    var go = Instantiate(template, checkerboard.transform);
                    go.name = $"Cell_{i}_{j}";
                    go.coordinateX = i;
                    go.coordinateY = j;
                    go.state = this;
                    go.gameObject.SetActive(true);
                }
            }
        }
        
        private void Update()
        {
        }
    }
}