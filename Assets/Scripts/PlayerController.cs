using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Transform segmentPrefab;
    [SerializeField] private int initialSize = 3;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private float initialGameSpeed = 0.1f;
    private Vector2 direction = Vector2.right;
    private List<Transform> _segments;

    private float gameSpeedChanger = 0.0025f;


    void Awake()
    {
        _segments = new List<Transform>();
    }

    void Start()
    {
        ResetState();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
            //transform.Rotate(0, 0, 90);
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
            //transform.Rotate(0, 0, -90);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
            //transform.Rotate(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
            //transform.Rotate(0, 0, -90);
        }
    }

    void FixedUpdate()
    {
        //this loop is to move the newly created snake body segment to follow the previous segment
        //hence it is done in reversed loop
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        //moving the snake's head
        transform.position = new Vector2(
            Mathf.Round(transform.position.x) + direction.x,
            Mathf.Round(transform.position.y) + direction.y
        );
    }

    void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;   //attaching the newly created segment to the last index of list

        _segments.Add(segment);
    }

    void Shrink()
    {
        Transform segment = _segments[_segments.Count - 1].transform;   //attaching the newly created segment to the last index of list
        _segments.Remove(segment);
        Destroy(segment.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Chicken")
        {
            IncreaseGameSpeed();
            Grow();
            scoreController.IncreaseScore(50);
        }
        else if (other.tag == "Obstacle")
        {
            ResetState();
            scoreController.ResetScore();
        }
        else if (other.tag == "Milk")
        {
            Shrink();
            scoreController.DecreaseScore(50);
        }
    }

    void ResetState()
    {
        Time.fixedDeltaTime = initialGameSpeed;
        #region remove
        //this loop is to destroy gameobject inside the segments one by one
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();  //clearing the segments
        #endregion remove

        #region spawn
        _segments.Add(transform);   //adding snake head into segments

        //this loop is to set snake's initial size
        for (int i = 1; i < initialSize; i++)
        {
            _segments.Add(Instantiate(segmentPrefab));
        }

        transform.position = Vector2.zero;  //setting snake's re-spwan position as zero,zero
        #endregion
    }

    public void IncreaseGameSpeed()
    {
        float currentGameSpeed = Time.fixedDeltaTime;
        float newGameSpeed = currentGameSpeed - gameSpeedChanger;
        Time.fixedDeltaTime = newGameSpeed;
    }
}
