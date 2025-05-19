using UnityEngine;

public class Roof : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        Destroy(other.gameObject.transform.parent.gameObject);
    }
}
