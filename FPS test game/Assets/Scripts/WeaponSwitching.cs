using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    [SerializeField]
    int selectedWeapon = 0;
    void Awake()
    {
        SelectWeapon();
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
        
    }
    public void ChangeToNextWeapon()
    {
        int previousSelectedWeapon = selectedWeapon;
        if (selectedWeapon >= transform.childCount - 1)
            selectedWeapon = 0;
        else
            selectedWeapon++;

        if (previousSelectedWeapon != selectedWeapon)
            SelectWeapon();
    }
}
