using UnityEngine;

public class LAZER : MonoBehaviour
{
private void OnTiggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("playerdead");
        }
    }
}
