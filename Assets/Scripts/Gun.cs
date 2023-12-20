using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] 
    [Range(0.5f,1.5f)]
    private float fireRate = 1;
    
    [SerializeField]
    [Range(1,10)]
    private int damage = 1;

    //[SerializeField] 
    //private Transform firePiont;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();
            }
        }
    }

    private void FireGun()
    {
        //Ray ray = new Ray(firePiont.position, firePiont.forward);
        RaycastHit hitInfo;
        
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin,ray.direction * 100, Color.red, 2f);

        
        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}
