using UnityEngine;

public class SmallGun : Guns
{
    float defaultFieldOfView;
    [SerializeField]
    float zoomPower = 0;//how much gun will zoom
    private void Start()=>defaultFieldOfView = mainCamera.fieldOfView;
    public void SmallGunShoot()
    {
        if (GunRedyToFire())
        {
            Shoot();
        }
    }
    public void SmallGunZoom(bool buttonIsDown)
    {
        if(gun.activeSelf)
         Zoom(buttonIsDown);
    }

    void Zoom(bool buttonIsDown)
    {
        if (buttonIsDown && zoomPower > 0)
            mainCamera.fieldOfView = defaultFieldOfView - zoomPower;
        if (!buttonIsDown)
            mainCamera.fieldOfView = defaultFieldOfView;
    }
}
