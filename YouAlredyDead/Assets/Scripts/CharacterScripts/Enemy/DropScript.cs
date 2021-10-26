using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class DropScript : MonoBehaviour
{
    [SerializeField] private List<Item> _items;

    private Health _hp;

    private void Awake()
    {
        _hp = GetComponent<Health>();

        _hp.OnDeath += DropItem;
    }

    private void DropItem()
    {
        _hp.OnDeath -= DropItem;

        foreach (Item item in _items)
        {
            int rmd = Random.Range(1, 11);

            if (item.DropChance >= rmd)
            {
                Instantiate(item, transform.position, Quaternion.identity);

                break;
            }
        }
    }
}
