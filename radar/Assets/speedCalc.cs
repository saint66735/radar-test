using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class speedCalc : MonoBehaviour
{
    public TextMeshProUGUI text;
    public List<RadarRay> rays = new List<RadarRay>();
    public float speed;
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        RadarRay[] rayArray = FindObjectsOfType<RadarRay>();
        for (int i = 0; i < rayArray.Length; i++)
        {
            rays.Add(rayArray[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        speed = CalculteSpeed();
        speed = (float)System.Math.Round(speed, 2);
        pos = CalculatePos();
        text.text = "speed of player: " + speed + "\n position is: " + pos;
    }
    float CalculteSpeed()
    {
        float tempSpeed = 0;
        int k = 0;
        foreach (RadarRay ray in rays)
        {
            if (ray.timeSinceLastHit < 1)
            {
                tempSpeed += ray.currentSpeed;
                k++;
            }

        }
        if (k > 0)
            return tempSpeed / k;
        else
            return 0;
    }
    Vector3 CalculatePos()
    {
        Vector3 tempPos = Vector3.zero;
        int k = 0;
        foreach (RadarRay ray in rays)
        {
            if (ray.timeSinceLastHit < 1)
            {
                tempPos += ray.newHit;
                k++;
            }

        }
        if (k > 0)
            return tempPos / k;
        else
            return Vector3.zero;
    }
}
