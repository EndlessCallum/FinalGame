using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Destroy the object past a certain point.
    private float outOfBound = -5;

    // Speed of the Bullet.
    public float speed = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Moving the bullet
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // Destroying Object when past certain X point
        if(transform.position.x < outOfBound)
        {
            Destroy(gameObject);
        }

    }
}
