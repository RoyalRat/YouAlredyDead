using UnityEngine;

public class Slash : MonoBehaviour
{
    public void TakeSlash()
    {
        Collider[] coll = Physics.OverlapSphere(transform.position, 2f);

        foreach (Collider collider in coll)
        {
            if (collider.gameObject.GetComponent<PlayerMovemed>())
            {
                collider.gameObject.GetComponent<Health>().TakeDamage(1);
                break;
            }
        }
    }
}
