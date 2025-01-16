using UnityEngine;

public class ItemDespawn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CorrectItem"))
        {

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("WrongItem"))
        {

            Destroy(collision.gameObject);
        }
    }
}
