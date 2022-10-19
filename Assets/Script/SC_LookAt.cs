using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_LookAt : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.LookAt(target,Vector3.back);
        transform.LookAt(target, Vector3.left);
        //transform.LookAt(target, Vector3.down);
    }
}
