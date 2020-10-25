using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Weapon Component that is responsable to create object and control's weapon creation
public class Weapon : MonoBehaviour
{
    [SerializeField, Tooltip("Weapon's information that will be used ")]
    private WeaponInfo weaponInfo;

    //current weapon's information to fire
    private WeaponInfo currentWeaponInfo;

    //amount time that enable to fire
    private float accumRecharge = 0;

    //Entity component 
    private Entity entityComp;

    //Weapon status 
    public WEAPONSTATUS weaponStatus = WEAPONSTATUS.STAND;
    private void Awake()
    {
        SetWeaponInfo(weaponInfo);

        entityComp = GetComponent<Entity>();
    }

    // Update is called once per frame
    void Update()
    {
        if(weaponStatus == WEAPONSTATUS.FIRE)
        {
            accumRecharge += Time.deltaTime;
            if (accumRecharge >= currentWeaponInfo.GetRechargeVelocity)
            {
                Debug.Log("Shot");
                entityComp.canShoot = true;

                accumRecharge = 0;
                weaponStatus = WEAPONSTATUS.STAND;
            }
        }
    }
    
    //Create Shot and add force to
    public void Shot()
    {
        if (currentWeaponInfo)
        {
            GameObject instance = currentWeaponInfo.GetBulletPrefabObject;
            GameObject _bullet = Instantiate(instance) as GameObject;
            Bullet _bulletComp = _bullet.GetComponent<Bullet>();
            Rigidbody _bulletRb = _bullet.GetComponent<Rigidbody>();

            var newPosition = transform.position + (transform.forward * .07f);
            _bullet.transform.position = newPosition;

            _bulletComp.SetDamage(currentWeaponInfo.GetFireForce);
            _bulletComp.SetLife(currentWeaponInfo.GetBulletLife);

            _bulletRb.AddForce(transform.forward * currentWeaponInfo.GetSpeed);
            
            entityComp.canShoot = false;
            weaponStatus = WEAPONSTATUS.FIRE;
        }
    }

    //Set Weapon's info
    public void SetWeaponInfo(WeaponInfo _info)
    {
        currentWeaponInfo = _info;

    }
}

//Weapon current status 
public enum WEAPONSTATUS{
    STAND,
    FIRE
}