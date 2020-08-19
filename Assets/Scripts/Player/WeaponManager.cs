using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon currentWeapon;

    public Transform weaponHolder;

    public bool HasRoomForWeapon => this.currentWeapon == null;

    // UI
    private AmmoUI ammoUI;

    /// =========================================================
    /// <summary>
    ///
    /// </summary>
    void Start()
    {
        this.ammoUI = FindObjectOfType<AmmoUI>();
        this.ammoUI.Display(false);

        Weapon[] weapons = this.GetComponentsInChildren<Weapon>();
        foreach (var w in weapons)
        {
            // ARREGLAME PLS
            this.PickUpWeapon(w, 9999);
        }
    }

    /// =========================================================
    /// <summary>
    ///
    /// </summary>
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

                this.ammoUI.Display(false);
            }
        }
    }

    /// =========================================================
    /// <summary>
    ///
    /// </summary>
    /// <param name="weapon"></param>
    /// <param name="startingAmmo"></param>
    public void PickUpWeapon(Weapon weapon, int startingAmmo)
    {
        weapon.transform.position = this.weaponHolder.position;
        weapon.transform.rotation = this.weaponHolder.rotation;
        weapon.transform.SetParent(this.weaponHolder);

        this.currentWeapon = weapon;

        if (this.currentWeapon is GunWeapon)
        {
            GunWeapon gun = this.currentWeapon as GunWeapon;

            gun.ui = this.ammoUI;

            gun.currentAmmo = startingAmmo;

            this.ammoUI.Display(true);
        }
        else
        {
            this.ammoUI.Display(false);
        }
    }

    /// =========================================================
    /// <summary>
    ///
    /// </summary>
    /// <param name="type"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public bool TryToRecharge(GunType type, int amount)
    {
        if (this.currentWeapon is GunWeapon == false)
            return false;

        GunWeapon gun = this.currentWeapon as GunWeapon;
        if (gun.type != type)
            return false;

        if (gun.isAmmoAtMax)
            return false;

        gun.currentAmmo += amount;

        return true;
    }
}
