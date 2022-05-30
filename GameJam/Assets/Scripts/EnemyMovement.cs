using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 offsetVector = playerPos - transform.position;
        float distance = offsetVector.magnitude;
        Vector3 enemyVelocity = (offsetVector / distance) * enemySpeed * Time.deltaTime;
        transform.position += enemyVelocity;
    }
}
