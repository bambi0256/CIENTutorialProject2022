using BallScripts;
using UnityEngine;

namespace TileScripts
{
    public class StartTile : MonoBehaviour
    {
        public GameObject Ball;
        public float DelayTime;

        private SpriteRenderer _sprite;
        private Sprite[] RoadSp;
        
        private CheckBoolUp Up;
        private CheckBoolRight Right;
        private CheckBoolDown Down;
        private CheckBoolLeft Left;
        
        private bool[] Direction = {false, false, false, false, false};
        // 0 = stop(GameOver), 1 = up, 2 = right, 3 = down , 4 = left
        [SerializeField]private int NextPos;

        private void Awake()
        {
            var position = transform.position;
            var BallPos = new Vector3(position.x, position.y, position.z - 1);
            Up = GetComponentInChildren<CheckBoolUp>();
            Right = GetComponentInChildren<CheckBoolRight>();
            Down = GetComponentInChildren<CheckBoolDown>();
            Left = GetComponentInChildren<CheckBoolLeft>();
            _sprite = GetComponent<SpriteRenderer>();
            RoadSp = Resources.LoadAll<Sprite>("RoadSp");
            Instantiate(Ball, BallPos, Quaternion.identity);
            Invoke(nameof(SetBallDir), DelayTime);
        }

        private void SetBallDir()
        {
            BallMove.BallDir = NextPos;
        }
        
        private void Update()
        {
            if (Up.Flag)
            {
                NextPos = 1;
                _sprite.sprite = RoadSp[1];
            }

            if (Right.Flag)
            {
                NextPos = 2;
                _sprite.sprite = RoadSp[2];
            }

            if (Down.Flag)
            {
                NextPos = 3;
                _sprite.sprite = RoadSp[3];
            }

            if (Left.Flag)
            {
                NextPos = 4;
                _sprite.sprite = RoadSp[4];
            }
        }
    }
}
