using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquip : MonoBehaviour
{
    public Transform weaponPoint;
    public GameObject weaponPrefab;

    private Weapon currentWeapon = null;
    private bool isEquipped = false;

    public void Start() {
        currentWeapon = weaponPrefab.GetComponent<Weapon>();
        CreateWeapon();

    }

    public void Toggle() {
        if (isEquipped) {
            Unequip();
        } else {
            Equip();
        }
    }

    public void Equip() {
        if (currentWeapon == null) {
            CreateWeapon();
        }
        currentWeapon.gameObject.SetActive(true);
        isEquipped = true;
    }

    public void CreateWeapon() {
        GameObject equippedWeapon = Instantiate(
            weaponPrefab,
            weaponPoint.position,
            weaponPoint.rotation,
            this.transform
        );
        currentWeapon = equippedWeapon.GetComponent<Weapon>();
        currentWeapon.gameObject.SetActive(false);
    }

    public void Unequip() {
        currentWeapon.gameObject.SetActive(false);
        isEquipped = false;
        
    }
}

