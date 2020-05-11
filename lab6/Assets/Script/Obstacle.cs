using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Vector2 iniPos;
    // Start is called before the first frame update
    void Start()
    {
        iniPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = iniPos + new Vector2(Mathf.Sin(Time.time) * 6, 0);
    }
}
