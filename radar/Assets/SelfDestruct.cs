using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float t = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, t);
    }
}
