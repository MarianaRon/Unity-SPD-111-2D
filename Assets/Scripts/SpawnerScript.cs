using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    [SerializeField]
    private GameObject pipePrefab;


    private float spawnPeriod = 3f;//���� 3 �������
    private float timeLeft;
    // Start is called before the first frame update
    
    void Start()
    {
        timeLeft = 0f;


    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            timeLeft = spawnPeriod;
            SpawnPipe();
        }
    }
    private void SpawnPipe()
    {
        var pipe = GameObject.Instantiate(pipePrefab);
        pipe.transform.position = this.transform.position + 
            Vector3.up * Random.Range(-1f, 1f);
    }
}
