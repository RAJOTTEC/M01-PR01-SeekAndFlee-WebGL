using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekAndFlee : MonoBehaviour
{
    [SerializeField]
    public Transform target;

    float stoppingDistance = 20;
    float maxSpeed = 5f;
    int turnSpeed = 5;
    public bool flee = false;

    void Start()
    {
        int num = Random.Range(0, 2);
        if (num == 0)
        {
            flee = false;
        }

        else
        {
            flee = true;
        }
    }

    void Update()
    {
        if ((Vector3.Distance(transform.position, target.position) < stoppingDistance) && flee == false)
        {
            Vector3 relativePos = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);

            Quaternion current = transform.localRotation;

            transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime * turnSpeed);

            transform.Translate(Vector3.forward * maxSpeed * Time.deltaTime);
        }

        else if ((Vector3.Distance(transform.position, target.position) < stoppingDistance) && flee == true)
        {
            Vector3 relativePos = transform.position - target.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);

            Quaternion current = transform.localRotation;

            transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime * turnSpeed);

            transform.Translate(Vector3.forward * maxSpeed * Time.deltaTime);
        }
    }
}
