using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CannonManager : MonoBehaviour {

    public static UnityEvent FiredEvent;

    [SerializeField]private float _force;
    public static float Force;

    public static Vector3 Position;


    private void Awake()
    {
        Force = _force;
        Position = transform.position;

        FiredEvent = new UnityEvent();
    }

    private void Update()
    {
        if(Force != _force)
        {
            Force = _force;
        }
    }

}
