using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWallTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private BreakableWall Wall;
    void Awake()
    {
        Wall = transform.parent.gameObject.GetComponent<BreakableWall>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Player")){
            if(true){ //Check if player is doing gravity slam
                Wall.Explode();
            }
        }
    }
}
