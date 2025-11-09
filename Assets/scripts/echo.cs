using UnityEngine;

public class echo : MonoBehaviour
{
    void Awake()
    {
        Destroy(this.gameObject, 0.5f);
    }
}
