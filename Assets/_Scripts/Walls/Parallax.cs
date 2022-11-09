using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private DaisyController daisy;
    [SerializeField] private Transform[] objects;

    List<Transform> objectsSpawned = new List<Transform>();
    

    void Update()
    {
        transform.localPosition += Vector3.up * Time.deltaTime * speed * daisy.GetPetalMultiplier();
        if(transform.localPosition.y >= 10)
            MoveWall();
    }

    void MoveWall()
    {
        transform.localPosition -= Vector3.up * 20;

        foreach(Transform t in objectsSpawned)
            Destroy(t.gameObject);
        
        objectsSpawned.Clear();

        for(int i = 0; i < 2; i++)
        {
            float height = Random.Range(transform.position.y + 4, transform.position.y - 4);
            int randomIndex = Random.Range(0, objects.Length);

            float xPos = transform.position.x + (Random.Range(0, 2) == 0 ? -3 : 3);

            Quaternion rot = Quaternion.identity;

            if(randomIndex == 0) //*ROCK
            {   
                rot = Quaternion.Euler(0, 0, Random.Range(0, 360));
                xPos = transform.position.x + (Random.Range(0, 2) == 0 ? -2.5f : 2.5f);
            }
            else if(randomIndex == 1) //*WIND TUNNEL
            {
                rot = Quaternion.FromToRotation(transform.right, Vector3.right * (xPos < 0 ? -1 : 1)) * objects[randomIndex].rotation;
            }
            else //*Water Droplet
            {
                height = transform.position.y + 20;
                xPos = Random.Range(-3, 3);
            }
            
            objectsSpawned.Add(Instantiate(objects[randomIndex], new Vector3(xPos, height, transform.position.z - 1), rot));
        }
    }


}
