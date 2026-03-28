using UnityEngine;




public class recollection : MonoBehaviour
{

[SerializeField] private GameObject effect;
[SerializeField] private float scoreValue;
[SerializeField] private scoredisplay puntos;

private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
     scoreValue.AddScore(scoreValue);
     Instantiate(effect, transform.position, Quaternion.Identity);
     Destroy(GameObject);
    }
}
}