using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicObject : MonoBehaviour
{
    public virtual void CollisionEnter(Collision collision, Transform collisionObject)
    {
        
    }

    public virtual void CollisionStay(Collision collision, Transform collisionObject)
    {

    }

    public virtual void CollisionExit(Collision collision, Transform collisionObject)
    {

    }
}
