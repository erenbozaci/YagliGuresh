using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] targets;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    Transform FindActiveTarget()
    {
        foreach(Transform target in targets)
        {
            if (target.gameObject.activeInHierarchy)
            {
                return target;
            }
        }
        return null;
    }
}
