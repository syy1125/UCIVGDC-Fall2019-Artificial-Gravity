using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReceptacle : PuzzleElement
{
    // Start is called before the first frame update
    public Vector3 ReceptacleOffset;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collider){
        if(collider.gameObject.GetComponent<LinkableObject>() != null){
            collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            collider.gameObject.transform.position = transform.position + ReceptacleOffset;
            collider.gameObject.transform.rotation = Quaternion.identity;
            State = 1;
            ActivateOthers();
        }
    }
}
