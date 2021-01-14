using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Bullet bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Vector3 direction = (point - transform.position).normalized;

            Bullet bullet = Instantiate(this.bullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().Fire(ray.direction);
            //Destroy(gameObject, 3);
        }
    }
}
