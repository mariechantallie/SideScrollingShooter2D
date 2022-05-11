using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] GameObject targetPrefab;
    [SerializeField] float fireRate;
    [SerializeField] float force;
    [SerializeField] Transform spawnPos;
    [SerializeField] Transform container;
    [Range(1f, 10f)]
    [SerializeField] float maxHeight;
    [Range(1f, 10f)]
    [SerializeField] float minHeight;

    private void Start() {
        StartCoroutine(Fire());
    }

    private IEnumerator Fire() {
        WaitForSeconds rate = new WaitForSeconds(fireRate);
        float randHeight;
        while(true) {
            var go = Instantiate(targetPrefab, container);
            go.transform.position = spawnPos.position;
            var rb = go.GetComponent<Rigidbody2D>();
            randHeight = Random.Range(maxHeight, minHeight);
            rb.AddForce(new Vector3(1f, randHeight).normalized * force);
            yield return rate;
        }
    }
}
