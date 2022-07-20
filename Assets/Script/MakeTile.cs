using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class MakeTile : MonoBehaviour
    {
        // 타일 타입 = 0: 경계 타일, 1: 일반 타일, 2: 종료 타일, 추후 추가
        public GameObject[] TilePref;
        public GameObject Ball;
    
        private Dictionary<int, MapSize> mapSizes;
        private int stage;
        private Vector3 BallPos;
        private Vector2 vec;

        // 축 별 타일 개수
        private int x;
        private int y;
    
        // 종료 타일 위치
        private int finx;
        private int finy;
    
        // 타일 1개의 길이의 절반
        private int pixel;
    
        private void Start()
        {
            pixel = 5;
        
            mapSizes = new Dictionary<int, MapSize>();

            stage = 1;
            mapSizes.Add(stage, new MapSize(10, 10, 1, 1, 10, 10));
            stage = 2;
            mapSizes.Add(stage, new MapSize(20, 20, 1, 1, 20, 20));
            stage = 3;
            mapSizes.Add(stage, new MapSize(30, 30, 5, 5, 25, 25));
        }

        public void MakeMap(int num)
        {
            x = mapSizes[num].X;
            y = mapSizes[num].Y;

            finx = mapSizes[num].FinX;
            finy = mapSizes[num].FinY;

            BallPos = new Vector3(mapSizes[num].StartX, mapSizes[num].StartY, 0);
        
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (i == finx - 1 && j == finy - 1)
                    {
                        vec = new Vector2(-(x - 1) * pixel + i, -(y - 1) * pixel + j);
                        Instantiate(TilePref[2], vec, Quaternion.identity);
                    }
                    else
                    {
                        vec = new Vector2(-(x - 1) * pixel + i, -(y - 1) * pixel + j);
                        Instantiate(TilePref[1], vec, Quaternion.identity);
                    }
                }
            }
            Instantiate(Ball, BallPos, Quaternion.identity);
        }
    }
}