using UnityEngine;

namespace Player
{
    public class PlayerControl : MonoBehaviour
    {
        private int realX;
        private int realY;
        private Transform follower;

        private void Start()
        {
        }

        // wasd 2d move
        private void Update()
        {
            var dx = Input.GetAxisRaw("Horizontal");
            var dy = Input.GetAxisRaw("Vertical");
            if (dx > 0)
            {
                realX++;
            }
            else if (dx < 0)
            {
                realX--;
            }

            if (dy > 0)
            {
                realY++;
            }
            else if (dy < 0)
            {
                realY--;
            }
        }

        private void FixedUpdate()
        {

        }
    }
}