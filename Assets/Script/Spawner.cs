using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabsArray;
    bool spawn = true;

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        var AttackerIndex = Random.Range(0, attackerPrefabsArray.Length);
        Spawn(attackerPrefabsArray[AttackerIndex]);
    }
    
    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation)
             as Attacker;
        newAttacker.transform.parent = transform;
    }
}
