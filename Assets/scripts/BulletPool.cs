using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletToPool;

    private int maxPoolSize = 15;
    private Stack<GameObject> inactiveBullets = new Stack<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (bulletToPool != null)
        {
            for (int i = 0; i < maxPoolSize; i++)
            {
                var newBullet = Instantiate(bulletToPool);
                newBullet.SetActive(false);
                inactiveBullets.Push(newBullet);
            }
        }
    }

    public GameObject GetBulletFromPool()
    {
        while (inactiveBullets.Count > 0)
        {
            var Object = inactiveBullets.Pop();

            if (Object != null)
            {
                Object.SetActive(true);
                return Object;
            }
        }

        return null;
    }

    public void ReturnBulletToPool(GameObject ObjectToDeactivate)
    {
        if (ObjectToDeactivate != null)
        {
            ObjectToDeactivate.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            ObjectToDeactivate.SetActive(false);
            inactiveBullets.Push(ObjectToDeactivate);
        }
    }
}
