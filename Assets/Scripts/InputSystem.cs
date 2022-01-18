using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputSystem : MonoBehaviour
{
    [Header("Swipe Events:")]
    [SerializeField] private UnityEvent right;
    [SerializeField] private UnityEvent left;
    [SerializeField] private UnityEvent up;
    [SerializeField] private UnityEvent down;

    private Vector2 startPosition;

    public void Enable()
    {
        Manager.Get.UpdateEvent.AddListener(Swipe);
    }



    public void Disable()
    {
        Manager.Get.UpdateEvent.RemoveListener(Swipe);
    }

    private void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 endPosition = Input.mousePosition;

            Vector2 direction = endPosition - startPosition;


            if(Mathf.Abs(direction.x)> Mathf.Abs(direction.y))
            {
                float length = Screen.width * 0.1f; //20%

                if(direction.x > length)
                {
                    print("Right Swipe");
                    right.Invoke();
                }
                if (direction.x < -length)
                {
                    print("Left Swipe");
                    left.Invoke();
                }
            }
            else
            {
                float length = Screen.height * 0.1f; //20%

                if (direction.y > length)
                {
                    print("Up Swipe");
                    up.Invoke();
                }
                if (direction.y < -length)
                {
                    print("Down Swipe");
                    down.Invoke();
                }
            }

        }


    }
}
