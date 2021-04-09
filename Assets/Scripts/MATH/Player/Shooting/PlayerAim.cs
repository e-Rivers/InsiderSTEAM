using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    // Public attributes
    public GameObject crosshairs;
    public GameObject bullet;
    public AmmoSystem ammoSystem;
    public int currAmmo = 15;
    public int maxAmmo = 15;
    public float fireRate = 0.1f;
    public bool canShoot = false;
    public bool isGrabbing = false;
    public bool canReload = false;
    // Private attributes
    private Transform crosshairsTf;
    private Animator crosshairsAnim;
    private Camera cam;
    private float fireTimer = 0.0f;
    private float reloadPromptTime = 1.0f;
    private float reloadPromptTimer = 0.0f;
    private int reloadPromptCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize components
        cam = Camera.main;
        crosshairsTf = crosshairs.transform;
        crosshairsAnim = crosshairs.GetComponentInChildren<Animator>();
        // Set player values
        currAmmo = 15;
        maxAmmo = 15;
        fireRate = 0.1f;
        canShoot = false;
        isGrabbing = false;
        canReload = false;
        fireTimer = 0.0f;
        reloadPromptTime = 1.0f;
        reloadPromptTimer = 0.0f;
        reloadPromptCount = 0;
        // Initialize ammo UI
        ammoSystem.DrawShells(currAmmo, maxAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse position
        Vector3 mouse = Input.mousePosition;
        // Get object position
        Vector3 screenPoint = cam.WorldToScreenPoint(transform.localPosition);
        // Get direction from player to mouse
        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        // Rotate crosshairs in mouse direction
        crosshairsTf.rotation = Quaternion.Euler(0f, 0f, angle);
        // Update fire rate timer
        if (fireTimer >= fireRate)
        {
            canShoot = true;
        } else
        {
            canShoot = false;
            fireTimer += Time.deltaTime;
        }
        // If player has no bullets
        if (currAmmo == 0)
        {
            // Make player able to reload
            canReload = true;
            canShoot = false;
            // Animate reload text
            if (reloadPromptTimer < reloadPromptTime)
            {
                if (reloadPromptCount % 2 == 0)
                {
                    ReloadText.DisplayReload();
                } else
                {
                    ReloadText.EmptyText();
                }
                reloadPromptTimer += Time.deltaTime;
            } else
            {
                reloadPromptCount++;
                reloadPromptTimer = 0.0f;
            }
        // Turn off reload animation
        } else
        {
            ReloadText.EmptyText();
        }

        // Get user input and shoot
        if (Input.GetKeyDown(KeyCode.Space) && canShoot && !isGrabbing) {
            // Shoot
            var bulletInstance = Instantiate(bullet, transform.localPosition, crosshairsTf.rotation);
            // Reset fire rate timer
            fireTimer = 0.0f;
            // Animate shooting
            crosshairsAnim.ResetTrigger("Fire");
            crosshairsAnim.SetTrigger("Fire");
            // Update UI's ammo section
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && canReload)
        {
            Reload();
            canReload = false;
        }

    }

    public void Shoot()
    {
        if (currAmmo > 0)
        {
            currAmmo--;
            ammoSystem.DrawShells(currAmmo, maxAmmo);
            fireTimer = 0.0f;
        }
    }

    public void Reload()
    {
        currAmmo = maxAmmo;
        ammoSystem.DrawShells(currAmmo, maxAmmo);
        canShoot = true;
    }
}
