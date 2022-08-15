using UnityEngine;
using System.Linq;
using BallScripts;

namespace TileScripts
{
    public class ChangeNoneTo : MonoBehaviour
    {
        private SpriteRenderer _sprite;
        private CheckBoolUp Up;
        private CheckBoolRight Right;
        private CheckBoolDown Down;
        private CheckBoolLeft Left;
        
        private readonly bool[] Direction = {false, false, false, false, false};
        // 0 = stop(GameOver), 1 = up, 2 = right, 3 = down , 4 = left
        private int dirNum;
        private bool preFlag;
        private bool nextFlag;
        private int PrePos;
        private int NextPos;
        
        private void Start()
        {
            Up = GetComponentInChildren<CheckBoolUp>();
            Right = GetComponentInChildren<CheckBoolRight>();
            Down = GetComponentInChildren<CheckBoolDown>();
            Left = GetComponentInChildren<CheckBoolLeft>();
            _sprite = gameObject.GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            CheckBool();
            CheckPrePos();
            if (nextFlag) return;
            CheckNextPos();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if ( col.CompareTag("Ball") && col.transform.position == transform.position)
                // 현재 위치(중앙에) 도달했을 때 공 방향 변경
            {
                BallMove.BallDir = NextPos;
            }
        }

        private void CheckBool()
        {
            if (Up.Flag) Direction[1] = true;
            if (Right.Flag) Direction[2] = true;
            if (Down.Flag) Direction[3] = true;
            if (Left.Flag) Direction[4] = true;
            
            dirNum= Direction.Count(c => c);
        }
        
        private void CheckPrePos()
        {
            if (dirNum != 1) return;
            if (Direction[1]) PrePos = 1;
            if (Direction[2]) PrePos = 2;
            if (Direction[3]) PrePos = 3;
            if (Direction[4]) PrePos = 4;
            preFlag = true;
            SetSprite();
        }

        private void CheckNextPos()
        {
            if (preFlag && dirNum != 2) return;
            if (Direction[1] && PrePos != 1) NextPos = 1;
            if (Direction[2] && PrePos != 2) NextPos = 2;
            if (Direction[3] && PrePos != 3) NextPos = 3;
            if (Direction[4] && PrePos != 4) NextPos = 4;
            nextFlag = true;
            SetSprite();
        }

        private void SetSprite()
        {
            switch (preFlag)
            {
                case true when !nextFlag:
                    switch (PrePos)
                    {
                        case 1:
                            _sprite.sprite = GameManager.TileSprite[1];
                            return;
                        case 2:
                            _sprite.sprite = GameManager.TileSprite[2];
                            return;
                        case 3:
                            _sprite.sprite = GameManager.TileSprite[3];
                            return;
                        case 4:
                            _sprite.sprite = GameManager.TileSprite[4];
                            return;
                    }
                    break;
                
                case true when nextFlag:
                    switch (PrePos)
                    {
                        case 1:
                            switch (NextPos)
                            {
                                case 2:
                                    _sprite.sprite = GameManager.TileSprite[5];
                                    return;
                                case 3:
                                    _sprite.sprite = GameManager.TileSprite[6];
                                    return;
                                case 4:
                                    _sprite.sprite = GameManager.TileSprite[7];
                                    return;
                            }
                            return;
                        case 2:
                            switch (NextPos)
                            {
                                case 1:
                                    _sprite.sprite = GameManager.TileSprite[5];
                                    return;
                                case 3:
                                    _sprite.sprite = GameManager.TileSprite[8];
                                    return;
                                case 4:
                                    _sprite.sprite = GameManager.TileSprite[9];
                                    return;
                            }
                            return;
                        case 3:
                            switch (NextPos)
                            {
                                case 1:
                                    _sprite.sprite = GameManager.TileSprite[6];
                                    return;
                                case 2:
                                    _sprite.sprite = GameManager.TileSprite[8];
                                    return;
                                case 4:
                                    _sprite.sprite = GameManager.TileSprite[10];
                                    return;
                            }
                            return;
                        case 4:
                            switch (NextPos)
                            {
                                case 1:
                                    _sprite.sprite = GameManager.TileSprite[7];
                                    return;
                                case 2:
                                    _sprite.sprite = GameManager.TileSprite[9];
                                    return;
                                case 3:
                                    _sprite.sprite = GameManager.TileSprite[10];
                                    return;
                            }
                            return;
                    }
                    break;
            }
        }
    }
}
