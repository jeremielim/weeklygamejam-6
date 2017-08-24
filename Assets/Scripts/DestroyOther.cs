using UnityEngine;

public class DestroyOther : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
    }
}
