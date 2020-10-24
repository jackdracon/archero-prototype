using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
public class Weapon : MonoBehaviour
{
    [SerializeField, Tooltip("Bullet prefab that will be created")]
    private GameObject bullet;

    [SerializeField, Tooltip("Weapon's information that will be used ")]
    private WeaponInfo weaponInfo;

    //current weapon's information to fire
    private WeaponInfo currentWeaponInfo;

    private float rechargingValue = 0;

    private void Awake()
    {
        currentWeaponInfo = weaponInfo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Shot
    public void Shot()
    {
        if (currentWeaponInfo)
        {
            GameObject _bullet = Instantiate(bullet) as GameObject;
            Bullet _bulletComp = _bullet.GetComponent<Bullet>();
            Rigidbody _bulletRb = _bullet.GetComponent<Rigidbody>();
            
            _bullet.transform.position = transform.position;

            _bulletComp.SetDamage(currentWeaponInfo.GetFireForce);

            _bulletRb.AddForce(transform.forward * currentWeaponInfo.GetSpeed);
        }
    }

    //Set Weapon's info
    public void SetWeaponInfo(WeaponInfo _info)
    {
        currentWeaponInfo = _info;
    }
}
