using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject prefabProjectile;
    public GameObject firePos;

    // Update is called once per frame
    void Update()
    {
        //shoots projectile
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Instantiate(prefabProjectile, firePos.transform.position, firePos.transform.rotation);
        }
    }
}
