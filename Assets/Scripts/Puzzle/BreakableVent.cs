using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableVent : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody _body;
    public string PhysicsLayer = "Debris";
    public float ExplosionForce = 500f;
    public float BreakIfPlayerFasterThan = 20f;
    private bool _exploded;
    private float _lastFrameVelocity;
    private float _currentFrameVelocity;
    Rigidbody _playerBody;


    void Awake()
    {
        GetComponent<MeshCollider>().convex = true;
        _body = GetComponent<Rigidbody>();
        _body.useGravity = false;
        _body.isKinematic = true;
        _exploded = false;
    }
    void Start(){
        _playerBody = Player.Instance.GetComponent<Rigidbody>();
        _currentFrameVelocity = _playerBody.velocity.magnitude;
        _lastFrameVelocity = _currentFrameVelocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _lastFrameVelocity = _currentFrameVelocity;
        _currentFrameVelocity = _playerBody.velocity.magnitude;

    }

    public void OnCollisionEnter(Collision collision){
        if(_exploded){
            return;
        }
        Player player = collision.gameObject.GetComponent<Player>();
        print(_lastFrameVelocity);
        if(player != null && _lastFrameVelocity >= BreakIfPlayerFasterThan){
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.localScale *= 0.8f;
            _body.isKinematic = false;
            _body.useGravity = true;
            _body.gameObject.layer = LayerMask.NameToLayer(PhysicsLayer);
            _body.AddExplosionForce(ExplosionForce, player.transform.position,10f);
            _exploded = true;
        }
    }
}
