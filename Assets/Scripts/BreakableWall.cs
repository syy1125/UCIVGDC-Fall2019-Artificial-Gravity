using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public Vector3 ExplosionOffset;
    public float ExplosionForce;
    public float ExplosionRadius;
    private Rigidbody[] Rigibodies;

    public string PhysicsLayer = "Debris";
    public GameObject Geometry;
    private bool Exploded = false;
    void Awake()
    {
        Rigibodies = GetChildren(Geometry);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Explode(){
        if(Exploded)
            return; //only explode once
        Exploded = true;
        foreach (Rigidbody rb in Rigibodies)
        {
            rb.isKinematic = false;
            rb.gameObject.layer = LayerMask.NameToLayer(PhysicsLayer);
            if (rb != null)
                rb.AddExplosionForce(ExplosionForce, transform.position +ExplosionOffset, ExplosionRadius);
        }
    }
    private Rigidbody[] GetChildren(GameObject Geometry){
        List<Rigidbody> rigidbodies = new List<Rigidbody>();
        foreach(Transform child in Geometry.transform){
            rigidbodies.Add(child.GetComponent<Rigidbody>());
        }
        return rigidbodies.ToArray();
    }
}
