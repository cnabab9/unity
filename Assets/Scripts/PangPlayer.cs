using Unity.VisualScripting;
using UnityEngine;

public class PangPlayer : MonoBehaviour
{
    public enum STATE
    {
        IDLE,
        MOVE,
        HIT
    }
    [SerializeField]
    private Sprite[] idleSprites;
    [SerializeField]
    private Sprite[] WalkSprites;
    private STATE _currentState;
    public SpriteRenderer Img_Renderer;
    public Sprite Sprite01;
    public Sprite New_sprite01;

    private void Start()
    {
        Img_Renderer.sprite = Sprite01;
        Img_Renderer = Sprite01.GetComponent<SpriteRenderer>();
    }
    private void MoveInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 pos = transform.position;
            pos.y += 10 * Time.deltaTime;
            transform.position = pos;
            Img_Renderer.sprite = New_sprite01;
            Img_Renderer.sprite = Sprite01;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 pos = transform.position;
            pos.y += -10 * Time.deltaTime;
            transform.position = pos;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 pos = transform.position;
            pos.x += -10 * Time.deltaTime;
            transform.position = pos;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 pos = transform.position;
            pos.x += 10 * Time.deltaTime;
            transform.position = pos;
        }
    }
    private float _speed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()//���������
    {
        Debug.Log("hi");
        _currentState = STATE.IDLE;
    }
    private void IDLE_Action()
    {
        Debug.Log("idle");
        MoveInput();
    }
    private void Move_Action()
    {
        Debug.Log("move");
        MoveInput();
    }
    private void WALK_Action()
    {
        Debug.Log("HIT");
    }
    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case STATE.IDLE:
                IDLE_Action();
                break;
                case STATE.MOVE:
                Move_Action();
                break;
                case STATE.HIT:
                WALK_Action();
                break;
        }


        if (Input.GetMouseButtonDown(0)) //����
        {
            _currentState = STATE.IDLE;
        }
        if (Input.GetMouseButtonDown(1))
        {
            _currentState = STATE.HIT;
        }
       
    }
}
