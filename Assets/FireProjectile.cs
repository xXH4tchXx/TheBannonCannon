using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireProjectile : MonoBehaviour {

    public GameObject Prefab;
    public float Speed;

    [Space (10)]
    public Animator BarrelAnim;

    [Space(10)]
    public UnityEvent Fire;


    private void Start()
    {
        StartCoroutine(FireCoroutine());

    }
    private void Update()
    {

        if (Input.GetKeyUp(KeyCode.F))
        {
            StartCoroutine(FireCoroutine());
        }

    }

    IEnumerator FireCoroutine()
    {

        yield return new WaitForSeconds(1.0f);

        BarrelAnim.SetTrigger("Fire");

        CannonManager.FiredEvent.Invoke();

        Fire.Invoke();

        yield return new WaitForSeconds(0.1f);

        Shoot();

        StartCoroutine(FireCoroutine());
    }

    void Shoot()
    {

        Rigidbody _rigid = Instantiate(Prefab, transform.position,Quaternion.identity, null).GetComponent<Rigidbody>();
        _rigid.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0,0,-90));

        _rigid.AddForce(transform.right * Speed,ForceMode.Impulse);
        _rigid.AddForceAtPosition(-transform.up * 10, transform.position, ForceMode.Impulse);

    }

    public void ToggleParticleFX(GameObject objRef)
    {
        StartCoroutine(ToggleFXObject(objRef.GetComponent<ParticleSystem>()));
    }

    IEnumerator ToggleFXObject(ParticleSystem particle)
    {
        particle.gameObject.SetActive(true);
        yield return new WaitForSeconds(particle.main.startLifetime.constant);
        particle.gameObject.SetActive(false);
    }
}
