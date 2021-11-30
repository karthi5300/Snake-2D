using UnityEngine;

public class StarController : MonoBehaviour
{
    [SerializeField] AudioClip scoreBoostSound;

    public BoxCollider2D gridArea;

    void Start()
    {
        Invoke("RandomizeStar", 5f);
    }

    private void RandomizeStar()
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
        if (other.tag == "Player")
        {
            SoundManager.Instance.Play(scoreBoostSound);
            gameObject.SetActive(false);
            Invoke("RandomizeStar", 5f);
        }
    }

}