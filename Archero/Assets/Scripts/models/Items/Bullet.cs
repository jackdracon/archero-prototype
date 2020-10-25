using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //damage's value
    private float damage;

    //lifespan
    private float lifespan;

    //Accumulate the lifespan's passed since your creation
    private float accumLifespan = 0;
    
    //Set the damage's value
    public void SetDamage(float _value)
    {
        damage = _value;
    }

    //lifespan object
    public void SetLife(float _value)
    {
        lifespan = _value;
    }

    //udate called every frame
    private void Update()
    {
        accumLifespan += Time.deltaTime;
        if (accumLifespan >= lifespan)
        {
            Debug.Log("KILL BULLET");
            Destroy(this.gameObject);
        }
    }

    ///When the object collides with someobject
    private void OnCollisionEnter(Collision collision)
    {
        var _other = collision.gameObject.GetComponent<Entity>();
        if (_other)
        {
            _other.Damage(damage);
        }

        Destroy(this.gameObject);
    }
}
