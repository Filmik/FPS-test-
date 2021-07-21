using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    [SerializeField]
    int selectedWeapon = 0;
    [SerializeField]
    GameObject crosshair; 
    void Awake()=>SetActiveChild(selectedWeapon, transform);//select weapon
    
    public void ChangeToNextWeapon()
    {
        int previousSelectedWeapon = selectedWeapon;
        if (selectedWeapon >= transform.childCount - 1)
            selectedWeapon = 0;
        else
            selectedWeapon++;

        if (previousSelectedWeapon != selectedWeapon)
        {
            SetActiveChild(selectedWeapon, transform);//select weapon
            SetActiveChild(selectedWeapon, crosshair.transform);//change crosshair
        }
    }
    void SetActiveChild(int childNumber,Transform parent)
    {
        int i = 0;
        foreach (Transform childTransform in parent)
        {
            if (i == childNumber)
                childTransform.gameObject.SetActive(true);
            else
                childTransform.gameObject.SetActive(false);
            i++;
        }
    }
}
