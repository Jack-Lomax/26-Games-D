using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DaisyGraphics : MonoBehaviour
{
    [SerializeField] private Petal[] petals;
    [SerializeField] private GameObject deadPetal;

    public int numPetals {get; private set;}

    void Start()
    {
        numPetals = petals.Length;
    }

    void Update()
    {
        
    }

    public void RemovePetal()
    {
        foreach(Petal petal in petals)
        {
            if(!petal.isPicked)
            {
                numPetals--;
                petal.Pick();
                Instantiate(deadPetal, petal.transform.position, petal.transform.rotation);
                return;
            }
        }
    }

    void GrowPetal()
    {
        foreach(Petal petal in petals.Reverse())
        {
            if(petal.isPicked)
            {
                numPetals++;
                petal.Grow();
                return;
            }
        }
    }


}
