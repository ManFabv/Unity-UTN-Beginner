using UnityEngine;

public class LootDrop : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private GameObject[] LootPrefabs;
    [SerializeField] private int LootProbability = 20;
#pragma warning restore 0649

    private void Awake()
    {
        if (LootPrefabs == null || LootPrefabs.Length == 0)
            Debug.LogError("EL " + typeof(GameObject) + " ES NULO EN " + nameof(LootPrefabs));
    }

    public void Murio()
    {
        DropLoot();
    }
    
    public void DropLoot()
    {
        if (LootPrefabs != null && LootPrefabs.Length > 0)
        {
            int randomProbability = Random.Range(0, 100);
            bool canDropLoot = LootProbability <= randomProbability;

            if (canDropLoot)
            {
                int lootPrefabIndex = Random.Range(0, LootPrefabs.Length);
                GameObject loot = LootPrefabs[lootPrefabIndex];
                Instantiate(loot, this.transform.position, this.transform.rotation);
            }
        }
    }
}
