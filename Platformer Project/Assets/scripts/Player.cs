using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start, Update 유니티 이벤트 함수의 같은 이름이 있는지 조사
    // 같은 이름이 있으면 유니티에서 정해놓은 실행 시간에 그 함수를 실행

    // FPS : Frame Per Second; 초당 몇 프레임
    // 프레임 : 이미지 1장 게임엔진이 이미지 1장을 생성하는데 걸리는 시간
    // ex). 60FPS : 1초당 60프레임 생성

    // 속도, 방향
    [Header("Move")]
    public float moveSpeed = 3f;  // 캐릭터의 이동 속도
    public float jumpForce = 5f;  // 플레이어의 점프
    private float moveInput;  // 플레이어의 방향 및 인풋 데이터 저장

    public Transform startTransform;  // 캐릭터가 시작할 위치를 저장하는 변수
    public Rigidbody2D rigidbody2D;

    [Header("jump")]
    public bool isGrounded;  // true : 점프가능, false : 점프불가능
    public float groundDistance = 2f;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    // 첫 프레임이 불러지기 전에 (한번) 시작한다
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        // 현재 내 위치 <= 새로운 x, y 저장하는 데이터 타입 (현재 x좌표, 10, y좌표)
        // transform.position = new Vector2(transform.position.x, 10);

        // 
        transform.position = startTransform.position;
    }

    // Update is called once per frame
    // 1 프레임에 한번 호출된다
    void Update()
    {
        
        // 플레이어의 
        moveInput = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(moveSpeed * moveInput, rigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            // 점프 : Y Position_rigidbody Y velocity를 점프 파워만큼 올려주면 되다
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        }

        // isGrounded = Physics2D.Raycast(transform.position, Vector2.dowm, groundDistance, groundLayer);
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundDistance));
    }
}
