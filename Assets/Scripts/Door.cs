using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject DoorLeft;
    public GameObject DoorRight;
    Vector3 LeftPos;
    Vector3 RightPos;
    public float speed;
    public float dist;
    bool toOpen = false;
    bool toClose = false;
    public string playerTag;

    private void Start()
    {
        LeftPos = DoorLeft.transform.position;
        RightPos = DoorRight.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            toOpen = true;
            toClose = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            toOpen = false;
            toClose = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (toOpen)
        {
            DoorLeft.transform.position = new Vector3(DoorLeft.transform.position.x, DoorLeft.transform.position.y, DoorLeft.transform.position.z-speed);
            if(DoorLeft.transform.position.z < LeftPos.z - dist)
            {
                DoorLeft.transform.position = new Vector3(DoorLeft.transform.position.x, DoorLeft.transform.position.y, LeftPos.z - dist);
                toOpen = false;
            }

            DoorRight.transform.position = new Vector3(DoorRight.transform.position.x, DoorRight.transform.position.y, DoorRight.transform.position.z + speed);
            if (DoorRight.transform.position.z > RightPos.z + dist)
            {
                DoorRight.transform.position = new Vector3(DoorRight.transform.position.x, DoorRight.transform.position.y, RightPos.z + dist);
                toOpen = false;
            }
        }

        if (toClose)
        {
            DoorLeft.transform.position = new Vector3(DoorLeft.transform.position.x, DoorLeft.transform.position.y, DoorLeft.transform.position.z + speed);
            if (DoorLeft.transform.position.z > LeftPos.z)
            {
                DoorLeft.transform.position = new Vector3(DoorLeft.transform.position.x, DoorLeft.transform.position.y, LeftPos.z);
                toClose = false;
            }

            DoorRight.transform.position = new Vector3(DoorRight.transform.position.x, DoorRight.transform.position.y, DoorRight.transform.position.z - speed);
            if (DoorRight.transform.position.z < RightPos.z)
            {
                DoorRight.transform.position = new Vector3(DoorRight.transform.position.x, DoorRight.transform.position.y, RightPos.z);
                toClose = false;
            }
        }
    }
}
