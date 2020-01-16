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
        float xMove = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        float yMove;
        float zMove = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;

        _rig.velocity = new Vector3(xMove, _rig.velocity.y, zMove);
    }
}
