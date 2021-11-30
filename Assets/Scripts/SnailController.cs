using UnityEngine;

public class SnailController : MonoBehaviour
{
    [SerializeField] AudioClip timeSlowSound;

    public BoxCollider2D gridArea;

    void Start()
    {
        Invoke("RandomizeSnail", 5f);
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
            SoundManager.Instance.Play(timeSlowSound);
            gameObject.SetActive(false);
            Invoke("RandomizeSnail", 5f);
        }
    }

}