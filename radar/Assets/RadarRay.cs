using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RadarRay : MonoBehaviour
{
    public GameObject mark;
    Vector3 lastHit;
    public Vector3 newHit;

    float lastHitTime;
    float newHitTime;
    public float deltaPos;
    public float deltaTime;
    public float currentSpeed;
    public float timeSinceLastHit;
    // Update is called once per frame
    private void Start()
    {
        lastHit = Vector3.zero;
        newHit = Vector3.zero;
    }
    void FixedUpdate()
    {
        //Debug.DrawLine(transform.position, transform.forward * 100, Color.red, .5f);
        RaycastHit hit;
        timeSinceLastHit += Time.deltaTime;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            deltaTime = newHitTime - lastHitTime + 0.5f;
            deltaPos = Vector3.Distance(lastHit, newHit);
            currentSpeed = deltaPos / (deltaTime);
            lastHitTime = newHitTime;
            newHitTime = Time.time;
           // Debug.Log($"before change old pos {lastHit}, new pos {newHit}");
            lastHit = new Vector3(newHit.x, newHit.y, newHit.z);
            newHit = hit.transform.gameObject.transform.position;
         //   Debug.Log($"old pos {lastHit}, new pos {newHit}");

            timeSinceLastHit = 0;
            Instantiate(mark, hit.point, Quaternion.identity);
            newHit = hit.point;
        }

    }
}
