using System;
using System.Data.Common;
using UnityEngine;

namespace Script.TileScripts
{
    public enum Direction{
        up = 0,
        right = 1, 
        left = 2,
        down = 3
    }
    public class TileVariable : MonoBehaviour
    {
        public static bool up;
        public static bool right;
        public static bool left;
        public static bool down;

        public static Direction curDir;
        public static Direction nextDir;

        private int num;

        private void Start()
        {
            up = false;
            right = false;
            left = false;
            down = false;
        }

        private void CountBlock()
        {
            num = 0;
            if (up) num += 1;
            if (right) num += 1;
            if (left) num += 1;
            if (down) num += 1;
        }

        private void SetDir()
        {
            CountBlock();
            switch (num)
            {
                case 1:
                    if (up) curDir = Direction.up;
                    if (right) curDir = Direction.right;
                    if (left) curDir = Direction.left;
                    if (down) curDir = Direction.down;
                    break;
                case 2:
                    switch (curDir)
                    {
                        case Direction.up:
                        {
                            if (right) nextDir = Direction.right;
                            if (left) nextDir = Direction.left;
                            if (down) nextDir = Direction.down;
                            break;
                        }
                        case Direction.right:
                        {
                            if (up) nextDir = Direction.up;
                            if (left) nextDir = Direction.left;
                            if (down) nextDir = Direction.down;
                            break;
                        }
                        case Direction.left:
                        {
                            if (up) nextDir = Direction.up;
                            if (right) nextDir = Direction.right;
                            if (down) nextDir = Direction.down;
                            break;
                        }
                        case Direction.down:
                        {
                            if (up) nextDir = Direction.up;
                            if (right) nextDir = Direction.right;
                            if (left) nextDir = Direction.left;
                            break;
                        }
                        default:
                        {
                            nextDir = curDir;
                            break;
                        }
                    }
                    break;
                default:
                    return;
            }
        }
    }
}
