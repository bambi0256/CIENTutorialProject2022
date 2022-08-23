using UnityEngine;
using System.Linq;
using BallScripts;

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
        
        private bool[] Direction = {false, false, false, false, false};
        // 0 = stop(GameOver), 1 = up, 2 = right, 3 = down , 4 = left
        
        [SerializeField]private int dirNum;
        [SerializeField]private bool preFlag;
        [SerializeField]private bool nextFlag;
        [SerializeField]private int PrePos;
        [SerializeField]private int NextPos;
        
        private void Start()
        {
            Up = GetComponentInChildren<CheckBoolUp>();
            Right = GetComponentInChildren<CheckBoolRight>();
            Down = GetComponentInChildren<CheckBoolDown>();
            Left = GetComponentInChildren<CheckBoolLeft>();
            _sprite = GetComponent<SpriteRenderer>();
            RoadSp = Resources.LoadAll<Sprite>("RoadSp");
            CheckPrePos();
        }

        private void Update()
        {
            CheckPrePos();
            CheckNextPos();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if ( col.CompareTag("Ball") && col.transform.position == transform.position)
                // 공이 현재 위치(중앙에) 도달했을 때 공 방향 변경
            {
                BallMove.BallDir = NextPos;
            }
        }

        private void CheckBool()
        {
            if (Up.Flag) Direction[1] = true;
            else Direction[1] = false;
            if (Right.Flag) Direction[2] = true;
            else Direction[2] = false;
            if (Down.Flag) Direction[3] = true;
            else Direction[3] = false;
            if (Left.Flag) Direction[4] = true;
            else Direction[4] = false;
            
            dirNum= Direction.Count(c => c);
        }
        
        private void CheckPrePos()
        {
            CheckBool();
            if (preFlag || dirNum != 1) return;
            if (Direction[1]) PrePos = 1;
            if (Direction[2]) PrePos = 2;
            if (Direction[3]) PrePos = 3;
            if (Direction[4]) PrePos = 4;
            preFlag = true;
            SetSprite();
        }

        private void CheckNextPos()
        {
            CheckBool();
            if (nextFlag || dirNum != 2) return;
            if (Direction[1] && PrePos != 1) NextPos = 1;
            if (Direction[2] && PrePos != 2) NextPos = 2;
            if (Direction[3] && PrePos != 3) NextPos = 3;
            if (Direction[4] && PrePos != 4) NextPos = 4;
            nextFlag = true;
            SetSprite();
        }

        private bool Compare(int a, int b)
        {
            return (a == PrePos && b == NextPos) || (a == NextPos && b == PrePos);
        }

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
