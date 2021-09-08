using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour
{
    public int width = 10;
    public int height = 5;
    
    public int[,] MakeMyMap()
    {
        int[,] map = new int[width, height];
        for (int i = 0; i <width; i++)
        {
            for (int x = 0; x < height; x++)
            {
                map[i, x] = 0;
                //print(map[i, x]);
              
            }
           
        }
        map[1, 0] = 1;
        map[1, 1] = 1;
        map[1, 2] = 1;
        map[3, 2] = 1;
        map[3, 3] = 1;
        map[3, 4] = 1;
        map[4, 2] = 1;
        map[5, 1] = 1;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                print(map[i, j]);
            }

        }
        return map;
    }
    private void Start()
    {
        MakeMyMap();
    }


}
