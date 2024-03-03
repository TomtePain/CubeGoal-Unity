using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speedRotation;
    
    void Update()
    {
        transform.Rotate(new Vector3(0, 5 * speedRotation *Time.deltaTime , 0));
    }
}
