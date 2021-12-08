using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField] AudioClip shieldActivatedSound;
    [SerializeField] private ShieldBarController shieldBarController;
    [SerializeField] private int shieldTimer = 7;

    public BoxCollider2D gridArea;

    void Start()
    {
        Invoke("RandomizeShield", shieldTimer);
    }

    private void RandomizeShield()
    {
        //get the area size
        Bounds bounds = gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
        gameObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            EnableShieldBar();
            SoundManager.Instance.Play(shieldActivatedSound);
            gameObject.SetActive(false);
            Invoke("RandomizeShield", shieldTimer);
        }
    }

    public void EnableShieldBar()
    {
        shieldBarController.EnableSnailBar();
        shieldBarController.SetSnailBarTimer(shieldTimer);
    }

}
