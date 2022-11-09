using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDroplet : MonoBehaviour
{
    void Update()
    {
        transform.position -= Vector3.up * Time.deltaTime * 15;
    }
}
