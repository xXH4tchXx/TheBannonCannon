using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class GlobalRigidReact : MonoBehaviour {

    Rigidbody _rigid;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        CannonManager.FiredEvent.AddListener(Fired);
    }

    void Fired ()
    {
        var heading = transform.position - CannonManager.Position;

        print("DotProduct = " +  Vector3.Dot(Vector3.Normalize(transform.position), Vector3.Normalize(CannonManager.Position)));

        _rigid.AddExplosionForce(CannonManager.Force, CannonManager.Position, 100, 1,ForceMode.Impulse);
        
    }

}

