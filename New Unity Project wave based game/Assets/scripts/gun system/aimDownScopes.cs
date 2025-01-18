using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimDownScopes : MonoBehaviour
{

    public Vector3 aimDownSight;
    public Vector3 hipFire;

    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            transform.localPosition = aimDownSight;
        }
        if (Input.GetMouseButtonUp(1))
        {
            transform.localPosition = hipFire;
        }
    }
}
