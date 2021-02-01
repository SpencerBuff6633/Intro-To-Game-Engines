using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [Range(0, 5)] public float lifespan;
    [Range(1,100)]public float speed = 10.0f;

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, lifespan);
    }

    public void Fire(Vector3 forward)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(forward * speed, ForceMode.VelocityChange);
    }

    
}
