using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private DaisyController daisy;

    void FixedUpdate()
    {
        transform.position -= Vector3.up * daisy.GetGravPosDelta().y;
    }

}
