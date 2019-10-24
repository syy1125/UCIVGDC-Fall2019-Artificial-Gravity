using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTest : MonoBehaviour
{

    public Vector3 ExplosionOffset;
    public float ExplosionForce;
    public float ExplosionRadius;
    private Rigidbody[] ChildBodies;

    public string PhysicsLayer = "Debris";
    void Awake()
    {
        ChildBodies = GetChildren();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){
            Explode();
        }
    }
    private void Explode(){
        foreach (Rigidbody rb in ChildBodies)
        {
            rb.isKinematic = false;
            rb.gameObject.layer = LayerMask.NameToLayer(PhysicsLayer);
            if (rb != null)
                rb.AddExplosionForce(ExplosionForce, transform.position +ExplosionOffset, ExplosionRadius);
        }
    }
    private Rigidbody[] GetChildren(){
        List<Rigidbody> rigidbodies = new List<Rigidbody>();
        foreach(Transform child in transform){
            rigidbodies.Add(child.GetComponent<Rigidbody>());
        }
        return rigidbodies.ToArray();
    }
}
