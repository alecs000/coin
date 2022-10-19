using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public static int countCoinAtStart;

    [SerializeField] private ParticleSystem particle;
    [SerializeField] private float speed;
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private UIManager uIManager;

    private Queue<Vector3> positions = new Queue<Vector3>();
    private ObservableVariable<int> countDestroyedCoin;
    private Vector3 lastMousePos = new Vector3(0,0,0);
    private Animator animator;
    private void Start()
    {
        countDestroyedCoin = new ObservableVariable<int>();
        uIManager.AddObservable(countDestroyedCoin);
        animator = GetComponent<Animator>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Click()
    {
        Vector3 mousePos;
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            positions.Enqueue(new Vector3(mousePos.x, mousePos.y, 0));
            GameObject line = Instantiate(linePrefab);
            line.GetComponent<LineRenderer>().SetPositions(new Vector3[]{lastMousePos, mousePos});
            lastMousePos = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            countDestroyedCoin.Value++;
            if (countDestroyedCoin.Value == countCoinAtStart)
            {
                Time.timeScale = 0;
                uIManager.Win();
            }
        }
        if (collision.CompareTag("Spike"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            particle.Play();
            animator.SetBool("isDestroy", true);
        }
    }
    public void EndGame()
    {
        uIManager.Lose();
    }
    void Move()
    {
        if (positions.Count ==0)
            return;
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, positions.Peek(), step);
        if(transform.position == positions.Peek())
        {
            positions.Dequeue();
        }
    }
    void Update()
    {
        Click();
        Move();
    }
}

