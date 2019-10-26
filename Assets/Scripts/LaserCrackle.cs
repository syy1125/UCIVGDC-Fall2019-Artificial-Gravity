using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCrackle : MonoBehaviour
{
    // Start is called before the first frame update
    public int NumInnerPoints;
    public float RedrawDelay;
    private float RedrawTimer = 0;
    public Vector3 RandomizedPointOffset;
    public Color ColorA;
    public Color ColorB;
    private LineRenderer MyRenderer;
    private Vector3[] Points;
    
    void Awake()
    {
        MyRenderer = GetComponent<LineRenderer>();
        MyRenderer.positionCount = NumInnerPoints+2;
        Points = new Vector3[NumInnerPoints+2];
        Redraw();
    }

    // Update is called once per frame
    void Update()
    {
        if(RedrawTimer < RedrawDelay){
            RedrawTimer += Time.deltaTime;
        } else {
            RedrawTimer = 0;
            Redraw();
        }
    }
    private void Redraw(){
        Points[0] = new Vector3(-0.5f,0,0); //First point is fixed
        Points[Points.Length-1] = new Vector3(0.5f,0,0); //Last point is fixed
        float _step = 1f/(NumInnerPoints+2);
        for(int i = 1; i < Points.Length-1; i++){ //Loop through inner points
            Points[i] = JitterPoint(new Vector3(-0.5f+_step*i,0,0));
        }
        MyRenderer.SetPositions(Points);
    }
    private Vector3 JitterPoint(Vector3 Vec){
        //return Vec with + or - X,Y,Z based on RandomizedPointOffset X,Y,Z
        int randSign = (Random.value > 0.5f) ? 1 : -1;
        float randX = randSign*RandomizedPointOffset.x*Random.value;
        randSign = (Random.value > 0.5f) ? 1 : -1;
        float randY = randSign*RandomizedPointOffset.y*Random.value;
        randSign = (Random.value > 0.5f) ? 1 : -1;
        float randZ = randSign*RandomizedPointOffset.z*Random.value;
        return Vec + new Vector3(randX,randY,randZ);
    }

}
