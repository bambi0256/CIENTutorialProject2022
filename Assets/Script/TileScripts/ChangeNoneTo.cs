using System.ComponentModel;
using UnityEngine;
using System.Linq;
using BallScripts;
using UnityEngine.UI;

namespace TileScripts
{
    public class ChangeNoneTo : MonoBehaviour
    {
        private SpriteRenderer _sprite;
        private Sprite[] RoadSp;

        private CheckBoolUp Up;
        private CheckBoolRight Right;
        private CheckBoolDown Down;
        private CheckBoolLeft Left;
        private CheckBallCollision BallCol;

        public int Type = 1;

        [SerializeField]private bool[] posDirection = { false, false, false, false, false };
        // 0 = stop(GameOver), 1 = up, 2 = right, 3 = down , 4 = left

        [SerializeField] private int dirNum;
        [SerializeField] private bool preFlag;
        [SerializeField] private bool nextFlag;
        [SerializeField] private int PrePos;
        [SerializeField] private int NextPos;

        private void Start()
        {
            Up = GetComponentInChildren<CheckBoolUp>();
            Right = GetComponentInChildren<CheckBoolRight>();
            Down = GetComponentInChildren<CheckBoolDown>();
            Left = GetComponentInChildren<CheckBoolLeft>();
            BallCol = GetComponentInChildren<CheckBallCollision>();
            _sprite = GetComponent<SpriteRenderer>();
            RoadSp = Resources.LoadAll<Sprite>("RoadSp");
            CheckPrePos();
        }

        private void Update()
        {
            CheckPrePos();
            CheckNextPos();
            CheckCollision();
        }

        private void CheckCollision()
        {
            if (!BallCol.isBallCol) return;
            BallMove.BallDir = NextPos;
        }

        private void CheckBool()
        {
            if (Up.posFlag) posDirection[1] = true;
            else posDirection[1] = false;
            if (Right.posFlag) posDirection[2] = true;
            else posDirection[2] = false;
            if (Down.posFlag) posDirection[3] = true;
            else posDirection[3] = false;
            if (Left.posFlag) posDirection[4] = true;
            else posDirection[4] = false;

            dirNum = posDirection.Count(c => c);
        }

        private void CheckPrePos()
        {
            CheckBool();
            if (preFlag || dirNum !< 1) return;
            if (posDirection[1]) PrePos = 1;
            if (posDirection[2]) PrePos = 2;
            if (posDirection[3]) PrePos = 3;
            if (posDirection[4]) PrePos = 4;
            preFlag = true;
            SetSprite();
        }

        private void CheckNextPos()
        {
            CheckBool();
            if (nextFlag || dirNum !< 2) return;
            if (posDirection[1] && PrePos != 1) NextPos = 1;
            if (posDirection[2] && PrePos != 2) NextPos = 2;
            if (posDirection[3] && PrePos != 3) NextPos = 3;
            if (posDirection[4] && PrePos != 4) NextPos = 4;
            nextFlag = true;
            SetSprite();
            Type = 2;
        }

        private bool Compare(int a, int b)
        {
            return (a == PrePos && b == NextPos) || (a == NextPos && b == PrePos);
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void SetSprite()
        {
            switch (nextFlag)
            {
                case false: 
                    switch (PrePos)
                    {
                        case 1: 
                            _sprite.sprite = RoadSp[1];
                            return;
                        case 2:
                            _sprite.sprite = RoadSp[2];
                            return;
                        case 3:
                            _sprite.sprite = RoadSp[3];
                            return;
                        case 4:
                            _sprite.sprite = RoadSp[4];
                            return;
                    }
                    return;
                
                case true:
                    if (Compare(1, 2))
                        _sprite.sprite = RoadSp[5];
                    if (Compare(1, 3))
                        _sprite.sprite = RoadSp[6];
                    if (Compare(1, 4))
                        _sprite.sprite = RoadSp[7];
                    if (Compare(2, 3))
                        _sprite.sprite = RoadSp[8];
                    if (Compare(2, 4))
                        _sprite.sprite = RoadSp[9];
                    if (Compare(3, 4))
                        _sprite.sprite = RoadSp[10];
                    return;
            }
        }
    }
}
