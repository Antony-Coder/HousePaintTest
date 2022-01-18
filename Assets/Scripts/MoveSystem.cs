using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform movableObject;

    private Vector3 direction;

    private Vector3 target;

    private bool isMove;
    private bool isEnabled;


    private List<Vector3> incorrectDirections = new List<Vector3>();

    public float Speed { get => speed; set => speed = value; }
    public Transform MovableObject { get => movableObject; set => movableObject = value; }
    public Vector3 Direction { get => direction; set => direction = value; }

    public void Stop()
    {
        print("Stop");
        isMove = false;
        Manager.Get.UpdateEvent.RemoveListener(MoveExecutor);

        incorrectDirections.Clear();
    }

    public void MoveRight() => Move(Vector3.right);

    public void MoveLeft() => Move(Vector3.left);

    public void MoveUp() => Move(Vector3.up);

    public void MoveDown() => Move(Vector3.down);


    public void Enable()
    {
        movableObject = Manager.Get.Player;
        isEnabled = true;
    }

    public void Disable()
    {
        isEnabled = false;
    }

    private void Move(Vector3 newDirection)
    {
        if (!isEnabled || isMove) return;

        isMove = true;
        direction = newDirection;
        direction = Manager.Get.Wall.TransformDirection(direction);

        target = Ray(direction);


        Manager.Get.UpdateEvent.AddListener(MoveExecutor);
    }

    private Vector3 Ray(Vector3 direction)
    {
        Vector3 point = Vector3.zero;
        RaycastHit hit;

        if (Physics.Raycast(movableObject.position, direction, out hit))
        {

            if (hit.transform.GetComponent<PhysicObject>() != null)
            {
                point = hit.point;
                point -= direction * 0.5f;
                
            }
            
        }

        return point;
    }

    private void MoveExecutor()
    {
        movableObject.position = Vector3.MoveTowards(movableObject.position, target, Time.deltaTime * speed);
        if (movableObject.position == target) Stop();

        Debug.DrawRay(movableObject.transform.position, direction * 10, Color.green);
    }






}
