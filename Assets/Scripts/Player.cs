using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform gunPosition;

    [SerializeField] GameObject bulletPrefab;

    [SerializeField] int bulletType = 0;

    public float sideSpeed = 5f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        float moveSide = Input.GetAxis("Horizontal");

        float movement = moveSide * sideSpeed * Time.deltaTime;

        transform.Translate(new Vector3(0f, 0f, -movement));

        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);

        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = PoolManager.Instance.GetPooledObjects(bulletType,gunPosition.position, gunPosition.rotation);
            
            if(bullet != null)
            {
                bullet.SetActive(true);
            }
            else
            {
                Debug.LogError("Pool demasiado pequeña");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }
    }
}
