using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation*Quaternion.Euler(0, 0, 1), 0.1f);
    }
}
