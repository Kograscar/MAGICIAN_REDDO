    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody _rig;

    [SerializeField] float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float actualSpeed = _speed;

        float xMove = Input.GetAxis("Vertical");
        float yMove = _rig.velocity.y;
        float zMove = Input.GetAxis("Horizontal");
        
        _rig.velocity = 
            (transform.forward * xMove +
            transform.up * yMove +
            transform.right * zMove) *
            _speed * Time.deltaTime;
    }
}
