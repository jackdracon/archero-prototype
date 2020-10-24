using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //damage's value
    private float damage;

    private float lifespan;
    //Set the damage's value
    public void SetDamage(float _value)
    {
        damage = _value;
    }

    ///When the object collides with someobject
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLLISION TO " + collision.contacts[0].otherCollider.name);
        var _other = collision.gameObject.GetComponent<Entity>();
        if (_other)
        {
            _other.Damage(damage);
        }

        Destroy(this);
    }
}
