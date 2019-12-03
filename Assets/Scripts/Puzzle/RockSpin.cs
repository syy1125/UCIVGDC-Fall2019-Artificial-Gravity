using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpin : MonoBehaviour
{
    public enum Axis{
        X,Y,Z,Random
    }
    public Axis RotateAxis;
    public float RotationSpeed;
    
    private float Timer;
    private Vector3 _rotation;
    void Awake()
    {
        
        if(RotateAxis == Axis.Random){
            RotateAxis = (Axis)Random.Range(0,3);
        }
        switch(RotateAxis){
            case Axis.X:
                _rotation = new Vector3(RotationSpeed,0,0);
                break;
            case Axis.Y:
                _rotation = new Vector3(0,RotationSpeed,0);
                break;
            case Axis.Z:
                _rotation = new Vector3(0,0,RotationSpeed);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotation*Time.deltaTime);
    }
}
