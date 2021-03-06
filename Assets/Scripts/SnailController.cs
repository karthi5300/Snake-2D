using UnityEngine;

public class SnailController : MonoBehaviour
{
    [SerializeField] AudioClip timeSlowSound;
    [SerializeField] private SnailBarController snailBarController;
    [SerializeField] private int snailTimer = 7;

    public BoxCollider2D gridArea;

    void Start()
    {
        Invoke("RandomizeSnail", snailTimer);
    }

    private void RandomizeSnail()
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
            EnableSnailBar();
            SoundManager.Instance.Play(timeSlowSound);
            gameObject.SetActive(false);
            Invoke("RandomizeSnail", snailTimer);
        }
    }

    public void EnableSnailBar()
    {
        snailBarController.EnableSnailBar();
        snailBarController.SetSnailBarTimer(snailTimer);
    }

}