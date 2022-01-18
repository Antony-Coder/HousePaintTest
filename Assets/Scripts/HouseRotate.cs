using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HouseRotate : MonoBehaviour
{
    [SerializeField] private float speedHouseRotation;
    private UnityAction endRotate;

    public UnityAction EndRotate { get => endRotate; set => endRotate = value; }


    public void Rotate()
    {
        StartCoroutine(RotateHandler());
    }

    private IEnumerator RotateHandler()
    {
        Manager manager = Manager.Get;
        float targetAngle = manager.House.eulerAngles.y +  90;

        Transform axis = Manager.Get.House.GetComponent<House>().AxisRotation;
        Quaternion rot = manager.House.rotation;

        while (manager.House.eulerAngles.y < targetAngle)
        {
            manager.House.RotateAround(axis.position,Vector3.up, Time.deltaTime * speedHouseRotation);
            yield return null;
        }

        manager.House.eulerAngles.Set(manager.House.eulerAngles.x, targetAngle, manager.House.eulerAngles.y);

        endRotate?.Invoke();
    }



}
