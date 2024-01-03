using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CloudsController : MonoBehaviour
{
    [SerializeField] GameObject[] clouds;
    private Transform spawnArea;
    public int maxCloudsOnSky = 20;
    public int currentCloudsOnSky=0;
    public Transform cloudsContainer;

    public Transform endClouds;

    private float areaX;
    private float areaY;
    private float areaZ;

    public float maxMoveSpeed = 10.0f;
    public float minMoveSpeed = 2.0f;

    private bool firstSpawn = true;
    private Vector3 spawnPosition;

    private void Start()
    {
        areaX = gameObject.GetComponent<BoxCollider>().size.x;
        areaY = gameObject.GetComponent<BoxCollider>().size.y;
        areaZ = gameObject.GetComponent<BoxCollider>().size.z;

        spawnArea = gameObject.GetComponent<Transform>();


        CloudsGenerator();
    }

    private void Update()
    {
            currentCloudsOnSky = cloudsContainer.childCount;

        if(maxCloudsOnSky > currentCloudsOnSky) 
        { 
        CloudsGenerator();
        }


        
    }

    private void CloudsGenerator()
    {
        for (int i = currentCloudsOnSky; i < maxCloudsOnSky; i++)
        {
            if(firstSpawn)
            {
             spawnPosition = GetFirstRandomSpawnPosition();
            }
            else
            {
             spawnPosition = GetRandomSpawnPosition();
            }


            int random = Random.Range(0, clouds.Length-1);

            GameObject cloud = Instantiate(clouds[random], spawnPosition, Quaternion.identity, cloudsContainer);

            foreach(Transform child in cloud.transform)
            {
                child.transform.position += new Vector3(0, 0, Random.Range(0, 60));
            }

            CloudMovement cloudMovement = cloud.AddComponent<CloudMovement>();
            cloudMovement.maxMoveSpeed = maxMoveSpeed;
            cloudMovement.minMoveSpeed = minMoveSpeed;
            cloudMovement.EndOfClouds = endClouds.transform.position;

            currentCloudsOnSky++;
            if(currentCloudsOnSky==maxCloudsOnSky) 
            { 
            firstSpawn= false;
            }

        }
    }

    Vector3 GetFirstRandomSpawnPosition()
    {
        float randomX = Random.Range(spawnArea.position.x - areaX / 2f, spawnArea.position.x + areaX / 2f);
        float randomY = Random.Range(spawnArea.position.y - areaY / 2f, spawnArea.position.y + areaY / 2f);
        float randomZ = Random.Range(spawnArea.position.z - areaZ / 2f, spawnArea.position.z + areaZ / 2f);
        return new Vector3(randomX, randomY, randomZ);
    }

    Vector3 GetRandomSpawnPosition()
    {
        float randomX = spawnArea.position.x - areaX;
        float randomY = Random.Range(spawnArea.position.y - areaY / 2f, spawnArea.position.y + areaY / 2f);
        float randomZ = Random.Range(spawnArea.position.z - areaZ / 2f, spawnArea.position.z + areaZ / 2f);
        return new Vector3(randomX, randomY, randomZ);
    }

}

public class CloudMovement : MonoBehaviour
{
    public float maxMoveSpeed;
    public float minMoveSpeed;
    public Vector3 EndOfClouds;
    public float randomMoveSpeed;


    void Update()
    {
        randomMoveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        // Przesuñ chmurê wzd³u¿ osi X
        transform.Translate(Vector3.right * randomMoveSpeed * Time.deltaTime);

        if(gameObject.transform.position.x >= EndOfClouds.x)
        {
            Destroy(gameObject);
        }
    }
}
