using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public GameObject FollowObject;
    private Vector3 Distance;
    float handYBegginerPos;
    void Start()
    {
        Distance = transform.position - FollowObject.transform.position;
        handYBegginerPos = FollowObject.transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,FollowObject.transform.position.y + Distance.y, Distance.z + FollowObject.transform.position.z);
    }

}