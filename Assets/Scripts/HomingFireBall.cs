using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingFireBall : MonoBehaviour
{
    [SerializeField] float _rotateSpeed = 10;
    [SerializeField] float _speed = 10;
    [SerializeField] GameObject _explosion;

    public Transform _target;

    public Rigidbody _rig;

    // Start is called before the first frame update
    void Start()
    {
        _rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion targetRotation = Quaternion.LookRotation(_target.position - transform.position);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotateSpeed * Time.deltaTime);

        _rig.velocity = transform.forward * _speed * Time.deltaTime;


        //Utilise ça

        /*
        if (target != null)
        {
            Vector3 direction = target.position - rig.position;
            direction.Normalize();
            Vector3 rotationAmount = Vector3.Cross(transform.forward, direction);
            rig.angularVelocity = rotationAmount * rotationSpeed;
        }

        rig.velocity = transform.forward * speed * Time.deltaTime;*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        PanikTime();
    }

    void PanikTime()
    {
        Destroy(Instantiate(_explosion, transform.position, transform.rotation), .75f);
        Destroy(gameObject);
    }
}
