using UnityEngine;

public class StickSettings : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //Legg til logikk her for � �ke antall stick player har, og UI endringer hvis n�dvendig
            gameObject.SetActive(false);
        }
    }
}