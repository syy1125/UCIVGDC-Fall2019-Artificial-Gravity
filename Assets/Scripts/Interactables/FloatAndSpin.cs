using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAndSpin : MonoBehaviour
{
    // Start is called before the first frame update
    public float RotationSpeed;
    public float HeightDelta;
    public float FloatingRate;
    private float Timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += FloatingRate*Time.deltaTime;
        transform.Rotate(0,RotationSpeed*Time.deltaTime,0);
        transform.position += transform.up*Mathf.Sin(Timer)*HeightDelta*Time.deltaTime;
    }
}
