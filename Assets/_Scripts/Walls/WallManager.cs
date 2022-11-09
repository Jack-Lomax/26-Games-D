using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] private Transform[] walls;
    [SerializeField] private Transform cam;

    float previousHeight = 10;
    int counter = 0;

    void Update()
    {
        if(cam.transform.position.y <= previousHeight)
        {
            counter++;
            Transform targetWall;
            if(counter % 2 == 0)
                targetWall = walls[1];
            else
                targetWall = walls[0];

            targetWall.position = new Vector3(targetWall.position.x, previousHeight - 10, transform.position.z);
            previousHeight = targetWall.position.y;
        }
    }

}
