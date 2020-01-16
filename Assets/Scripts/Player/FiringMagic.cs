using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringMagic : MonoBehaviour
{
    [SerializeField] Transform _magikBoule;

    [SerializeField] GameObject _fireBall;

    [SerializeField] float _fireDelay = .5f;

    AutoAim _autoAim;

    float _timer = 10f;

    void Start()
    {
        _autoAim = GetComponentInParent<AutoAim>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && _timer >= _fireDelay)
        {
            GameObject fireballClone = Instantiate(_fireBall, _magikBoule.position, _magikBoule.rotation);
            fireballClone.transform.LookAt(_autoAim._nearestEnnemy.position + new Vector3(0, 10, 0));
            //Time.timeScale = 0;

            Destroy(fireballClone, 5f);

            HomingFireBall _homing = fireballClone.GetComponent<HomingFireBall>();

            if(_autoAim._nearestEnnemy != null)
            {
                _homing._target = _autoAim._nearestEnnemy;
            }
            else
            {
                GameObject imaginaryPos = new GameObject();
                imaginaryPos.transform.position = transform.forward * 100000000;
                Destroy(imaginaryPos, 5f);
                _homing._target = imaginaryPos.transform;
            }

            Rigidbody rigidFire = fireballClone.GetComponent<Rigidbody>();

            //rigidFire.AddForce(new Vector3(1,0,1), ForceMode.Impulse);
            //fireballClone.transform.LookAt(rigidFire.velocity.normalized);

            _timer = 0;
        }
    }
}
