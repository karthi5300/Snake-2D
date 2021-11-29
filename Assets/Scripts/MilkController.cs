using UnityEngine;

public class MilkController : MonoBehaviour
{

    [SerializeField] AudioClip drinkSound;

    public BoxCollider2D gridArea;

    void Start()
    {
        Invoke("RandomizeMilk", 5f);
    }

    private void RandomizeMilk()
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
            SoundManager.Instance.Play(drinkSound);
            gameObject.SetActive(false);
            Invoke("RandomizeMilk", 5f);
        }
    }



}
