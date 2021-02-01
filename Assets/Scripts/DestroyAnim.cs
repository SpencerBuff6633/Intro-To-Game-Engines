using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnim : MonoBehaviour
{
    public GameObject destroyObject;

    public void DestroyEvent(float time)
    {
        Destroy(destroyObject, time);
    }
}
