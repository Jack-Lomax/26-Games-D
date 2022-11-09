using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedlineManager : MonoBehaviour
{
    [SerializeField] private DaisyGraphics daisy;
    [SerializeField] private Material speedlineMaterial;

    void Update()
    {
        float a = 0;
        if(!daisy) return;

        if(daisy.numPetals == 8)
            a = 0;
        else if(daisy.numPetals != 0)
            a = 0.125f * (8 / daisy.numPetals);
        else
            a = 1;

        speedlineMaterial.color = new Color(1,1,1, a);
    }
}
