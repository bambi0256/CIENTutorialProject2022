using BallScripts;
using UnityEngine;

namespace TileScripts
{
    public class StartTile : MonoBehaviour
    {
        public GameObject Ball;
        public float DelayTime;
        
        private bool canStart;

        public int Type = 1;

        private SpriteRenderer _sprite;
        private Sprite[] RoadSp;
        
        private CheckBoolUp Up;
        private CheckBoolRight Right;
        private CheckBoolDown Down;
        private CheckBoolLeft Left;
        
        [SerializeField]private int NextPos;

        private GameObject parentMap;
        [SerializeField] private GameObject generatedObjectsPrefab;
        private GameObject generatedObjects;

        private Vector3 BallPos;


        private void Awake()
        {
            var position = transform.position;
            BallPos = new Vector3(position.x, position.y, position.z - 1);
            Up = GetComponentInChildren<CheckBoolUp>();
            Right = GetComponentInChildren<CheckBoolRight>();
            Down = GetComponentInChildren<CheckBoolDown>();
            Left = GetComponentInChildren<CheckBoolLeft>();
            _sprite = GetComponent<SpriteRenderer>();
            RoadSp = Resources.LoadAll<Sprite>("RoadSp");
            DelayTime = 5.0f;
        }


        private void OnEnable()
        {
            this.canStart = false;

            this.NextPos = 0;
            BallMove.BallDir = NextPos;

            this.parentMap = transform.parent.gameObject;
            this.generatedObjects = Instantiate(this.generatedObjectsPrefab) as GameObject;
            this.generatedObjects.transform.parent = this.parentMap.transform;

            GameObject ball = Instantiate(Ball, BallPos, Quaternion.identity) as GameObject;
            ball.transform.parent = this.generatedObjects.transform;
            Invoke(nameof(CanStart), DelayTime);
        }


        private void OnDisable()
        {
            Destroy(this.generatedObjects);
        }


        private void CanStart()
        {
            canStart = true;
        }

        private void CheckPos()
        {
            if (Up.Flag)
            {
                NextPos = 1;
                _sprite.sprite = RoadSp[1];
                Type = 2;
                return;
            }

            if (Right.Flag)
            {
                NextPos = 2;
                _sprite.sprite = RoadSp[2];
                Type = 2;
                return;
            }

            if (Down.Flag)
            {
                NextPos = 3;
                _sprite.sprite = RoadSp[3];
                Type = 2;
                return;
            }

            if (Left.Flag)
            {
                NextPos = 4;
                _sprite.sprite = RoadSp[4];
                Type = 2;
                return;
            }
        }
        
        private void Update()
        {
            CheckPos();
            if (!canStart) return;
            BallMove.BallDir = NextPos;
            canStart = false;
        }
    }
}
