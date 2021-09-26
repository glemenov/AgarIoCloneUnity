using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float current_scale;

    void Awake()
    {
        current_scale = target.localScale.z;
    }
    void Update()
    {
        // If the scale of player has changed, increase the height of the camera
        if (current_scale != target.localScale.z)
        {
            offset.z -= target.localScale.z - current_scale;
            current_scale = target.localScale.z;
        }
    }

    // Late update to make camera movement smooth
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, offset.z);
    }
}
