using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDrawed : PhysicObject
{
    [SerializeField] private int xSize;
    [SerializeField] private int ySize;

    private void Start()
    {
        Manager.Get.Draw.DrawedPointsCalculate.AddListener(DrawedPoints);
    }

    private void DrawedPoints()
    {
        if (Manager.Get.Wall == transform.parent)
        {           
            Manager.Get.Draw.DrawedPointsCount += xSize * ySize;
        }
    }

    private List<Vector2> CoordsDrawedPoints()
    {
        List<Vector2> coords = new List<Vector2>();

        Vector2 origin = transform.localPosition - new Vector3(xSize / 2f, ySize / 2f,0);
        Vector2 coord;

        for (int j = 0; j < ySize; j++)
        {
            for (int i = 0; i < xSize; i++)
            {
                coord = origin + new Vector2(i, j);
                coords.Add(coord);
            }
        }

        return coords;
    }
}
