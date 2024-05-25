using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float secondSpawn = 0.5f;
    [SerializeField] private float minTras;
    [SerializeField] private float maxTras;

    private bool isSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        while (true)
        {
            // Wait for the previous prefab to be destroyed
            while (isSpawning)
            {
                yield return null;
            }

            isSpawning = true;

            float wanted = UnityEngine.Random.Range(minTras, maxTras);
            Vector3 position = new Vector3(wanted, transform.position.y, transform.position.z);
            GameObject gameObject = Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Length)], position, Quaternion.identity);

            // Wait for the current prefab to be destroyed before spawning a new one
            yield return new WaitUntil(() => gameObject == null);

            isSpawning = false;

            yield return new WaitForSeconds(secondSpawn);
        }
    }
}
