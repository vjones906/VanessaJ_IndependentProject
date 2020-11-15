using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupEnemy : MonoBehaviour
{
    public GameObject groupEnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Instantiate(groupEnemyPrefab, new Vector2(Random.Range(-35f, 35f), groupEnemyPrefab.transform.position.y + (250 + Random.Range(0.2f, 100.0f))), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
