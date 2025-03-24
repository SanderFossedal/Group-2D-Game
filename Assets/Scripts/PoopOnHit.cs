using UnityEngine;

public class PoopOnHit : MonoBehaviour
{
    private XPCounter xpCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xpCounter = Object.FindFirstObjectByType<XPCounter>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemies") && other.gameObject != GameObject.Find("Wall Bottom"))
        {
            xpCounter.xp = xpCounter.xp + 1;

            Destroy(this.gameObject);
        }
        else
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player") && other.gameObject.layer != LayerMask.NameToLayer("Poopie Prefabs"))
            {
                Destroy(this.gameObject);
            }

        }
    }
}
