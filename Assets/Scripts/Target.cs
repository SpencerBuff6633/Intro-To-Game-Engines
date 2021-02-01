using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int points = 100;
    public Material material;
    public GameObject destroyGameObject;
    public AudioSource destroyed;

    private void Start()
    {
        GetComponent<Renderer>().material = material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            destroyed.Play();
            // add score to game
            Game.Instance.AddPoints(points);
            if (destroyGameObject != null)
            {
                Destroy(destroyGameObject, .25f);
            }

        }
    }

}
