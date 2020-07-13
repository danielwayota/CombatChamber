using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon currentWeapon;

    public Transform weaponHolder;

    public bool HasRoomForWeapon => this.currentWeapon == null;

    void Start()
    {
        Weapon[] weapons = this.GetComponentsInChildren<Weapon>();
        foreach (var w in weapons)
        {
            this.PickUpWeapon(w);
        }
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (this.currentWeapon != null)
            {
                this.currentWeapon.Activate();
            }
        }

        if (Input.GetButton("Fire2"))
        {
            if (this.currentWeapon != null)
            {
                this.currentWeapon.Throw();
                this.currentWeapon = null;
            }
        }
    }

    public void PickUpWeapon(Weapon weapon)
    {
        weapon.transform.position = this.weaponHolder.position;
        weapon.transform.rotation = this.weaponHolder.rotation;
        weapon.transform.SetParent(this.weaponHolder);

        this.currentWeapon = weapon;
    }

}
