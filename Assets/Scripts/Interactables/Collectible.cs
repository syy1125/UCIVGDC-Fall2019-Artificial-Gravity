using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : PuzzleElement
{
    // Start is called before the first frame update
    private Collider MyCollider;
    private MeshRenderer MyRenderer;

    public string ItemName;
    public Sprite ItemSprite;
    void Awake()
    {
        MyCollider = gameObject.GetComponent<Collider>();
        MyRenderer = gameObject.GetComponent<MeshRenderer>();
    }
    void Start(){
        PlayerInventory.Instance.AddSprite(ItemName,ItemSprite);
    }

    // Update is called once per frame
    void Update()
    {
        //State=0 is visible and collectible
        //State=1 is after being collected 
        MyCollider.enabled = (State==0);
        MyRenderer.enabled = (State==0);
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.CompareTag("Player")){
            collider.gameObject.GetComponent<PlayerInventory>().AddItem(ItemName);
            ActivateOthers();
            State = 1;
            
        }
    }


}
