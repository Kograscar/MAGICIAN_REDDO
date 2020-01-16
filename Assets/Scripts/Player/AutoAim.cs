using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    public List<GameObject> _ennemiesNear;

    public Transform _nearestEnnemy;

    public Transform _autoAimPoint;


    List<GameObject> _ennemiesSeen;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemy"))
        {
            if (_nearestEnnemy != null)
            {
                if (Vector3.Distance(other.transform.position, transform.position) < Vector3.Distance(_nearestEnnemy.position, transform.position))
                {
                    _nearestEnnemy = other.transform;
                }
            }
            else
            {
                _nearestEnnemy = other.transform;
            }
        }
    }

    /*
    void Update()
    {
        RaycastHit hit;

        foreach (var item in _ennemiesNear)
        {
            if (Physics.Raycast(transform.position, ((transform.position + new Vector3(0, 1, 0)) - item.transform.position).normalized, out hit, Mathf.Infinity)){
                if(hit.collider == item)
                {
                    _ennemiesSeen.Add(item);

                    if (Vector3.Distance(transform.position, item.transform.position) < Vector3.Distance(transform.position, _nearestEnnemy.transform.position))
                    {
                        _nearestEnnemy = item.transform;
                    }
                }
            }
        }

        if (_nearestEnnemy != null && _ennemiesSeen != null)
        {
            if (!_ennemiesSeen.Contains(_nearestEnnemy.gameObject))
            {
                _nearestEnnemy = null;
                _autoAimPoint.gameObject.SetActive(true);
            }
        }
        else if(_ennemiesSeen == null)
        {
            _nearestEnnemy = null;
            _autoAimPoint.gameObject.SetActive(true);
        }
        

        if (_nearestEnnemy != null)
        {
            _autoAimPoint.gameObject.SetActive(true);
            _autoAimPoint.position = new Vector3(_nearestEnnemy.position.x, _nearestEnnemy.position.y + 1.5f, _nearestEnnemy.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemy"))
        {
            _ennemiesNear.Add(other.gameObject);
            if(_nearestEnnemy == null)
            {
                _nearestEnnemy = other.transform;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ennemy"))
        {
            _ennemiesNear.Remove(other.gameObject);
        }
    }*/
}
