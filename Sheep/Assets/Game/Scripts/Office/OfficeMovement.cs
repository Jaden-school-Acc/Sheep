using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public enum HorzDirection{

    left = -1,
    center = 0,
    right = 1
}

public enum VertDirection{

    up = 1,
    center = 0,
    down = -1
}

public enum TargetDirection{

    up = 1,
    down = -1,
    left = -2,
    right = 2,
    center = 0
}

public class OfficeMovement : MonoBehaviour
{

    [SerializeField] Camera cam;
    HorzDirection HorzDir = HorzDirection.center;
    VertDirection VertDir = VertDirection.center;

    TargetDirection targetDir = TargetDirection.center;

    Quaternion target;
    Quaternion vertTarget;

    [SerializeField] float speed;
    [SerializeField] float vertSpeed;

    // Start is called before the first frame update
    void Start()
    {
        target = cam.transform.rotation;
        vertTarget = target;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (targetDir)
        {

            case TargetDirection.left:
                cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, target, speed);
                break;
            case TargetDirection.right:
                cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, target, speed);
                break;
            case TargetDirection.up:
                cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, vertTarget, vertSpeed);
                break;
            case TargetDirection.down:
                cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, vertTarget, vertSpeed);
                break;
            default:
                cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, target, speed);
                cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, vertTarget, vertSpeed);
                break;
        }
    }

    public void RotRight(TargetDirection targetDirection = TargetDirection.center){
        

        if(HorzDir == HorzDirection.right)
            return;

        if(VertDir != VertDirection.center)
            return;
        
        targetDir = targetDirection;
        HorzDir += 1;
        target *= Quaternion.Euler(new Vector3(0, 60, 0));
    }

    public void RotLeft(TargetDirection targetDirection = TargetDirection.center){


        if(HorzDir == HorzDirection.left)
            return;
        
        if(VertDir != VertDirection.center)
            return;

        targetDir = targetDirection;
        HorzDir -= 1;
        target *= Quaternion.Euler(new Vector3(0, -60, 0));
    }

    public void RotUp(TargetDirection targetDirection = TargetDirection.center){


        if(VertDir == VertDirection.center)
            return;

        if(HorzDir != HorzDirection.center)
            return;

        targetDir = targetDirection;
        VertDir += 1;
        vertTarget *= Quaternion.Euler(new Vector3(-45f, 0, 0));
    }

    public void RotDown(TargetDirection targetDirection = TargetDirection.center){


        if(VertDir == VertDirection.down)
            return;

        if(HorzDir != HorzDirection.center)
            return;

        targetDir = targetDirection;
        VertDir -= 1;
        vertTarget *= Quaternion.Euler(new Vector3(45f, 0, 0));
    }
}
