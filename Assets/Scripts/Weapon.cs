using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0.1f;
    
    
    float fireTimer = 0;

    public Bullet bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
        //    Bullet bullet = Instantiate(this.bullet, transform.position, Quaternion.identity);
        //    bullet.GetComponent<Bullet>().Fire(ray.direction);
            
        //}
    }

    public bool Fire(Vector3 position, Vector3 direction)
    {
        if (fireTimer >= fireRate)
        {
            fireTimer = 0;
        Bullet bullet = Instantiate(this.bullet, position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Fire(direction);

            return true;
        }
        return false;
    }
}
