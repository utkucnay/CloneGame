using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public GameObject FollowObject;
    private Vector3 Distance;
    void Start()
    {
        Distance = transform.position - FollowObject.transform.position;

    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y, Distance.z + FollowObject.transform.position.z);
    }

}