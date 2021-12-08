using UnityEngine;

public class ChickenController : MonoBehaviour
{

    [SerializeField] AudioClip bloodSound;
    //[SerializeField] Level level;

    public BoxCollider2D gridArea;

    void Start()
    {
        RandomizeChicken();
    }

    private void RandomizeChicken()
    {
        //get the area size
        Bounds bounds = gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            SoundManager.Instance.Play(bloodSound);
            RandomizeChicken();
        }
    }

}
