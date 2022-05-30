using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int health = 100;
    public bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            alive = false;
            Destroy(this.gameObject);
            Debug.Log("dead");
        }

    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
    }
}
