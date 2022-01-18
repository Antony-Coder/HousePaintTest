using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Transform  axisRotation;

    [Header("В порядке : A B C D")]
    [SerializeField] private Transform[] walls;

    public Transform AxisRotation { get => axisRotation; }
    public Transform[] Walls { get => walls; set => walls = value; }

    public Transform WallA => Walls[0];
    public Transform WallB => Walls[1];
    public Transform WallC => Walls[2];
    public Transform WallD => Walls[3];


    public void  Initialize(Transform wallA, Transform wallB, Transform wallC, Transform wallD,Transform axisRotation)
    {

        this.axisRotation = axisRotation;

        walls = new Transform[4] { wallA, wallB, wallC, wallD };
    }
}
