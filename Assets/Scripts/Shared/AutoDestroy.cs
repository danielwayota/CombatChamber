using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float time = 1;

    void Awake()
    {
        Destroy(this.gameObject, this.time);
    }
}
