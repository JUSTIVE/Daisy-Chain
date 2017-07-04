using UnityEngine;
using System.Collections;

//enum for direction
public enum Direction{
	Up,
	Left,
	Right,
    Down
	}

public class Knight : MonoBehaviour {

    public float speed = 1.0f; //for move
    private Vector3 look;//daisy look vector
    private Vector3 move;//moving vector
    public bool nowRun;//is daisy able to run?
    private Animator anim;//daisy animation controller
    private bool anyKeyPress;//is daisy jumping or moving on this frame?
    private float tempy;//temp y value for look vec
    private bool isWater=false;//is daisy in water?
    private int jumpstyle;//jump multiplier for water
    //for sound
    public AudioClip jumpSound;
    private AudioSource source;
    
    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        look = new Vector3(0, 0, 0);
        nowRun = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        
    }
    void Awake()//use for sound
    {
        source = GetComponent<AudioSource>();
    }
    void setRun(bool value) {//모든 이동관련 제어
        nowRun = value;
    }
    void toggleRun(bool value)//make daisy run or not
    {
        Debug.Log("Booya"+nowRun);
        if (nowRun)
            nowRun = false;
        else
            nowRun = true;
    }
	// Update is called once per frame
	void Update () {
        anyKeyPress = false;
        if (nowRun) {//데이지가 이동 가능한 상황이면
            tempy = look.y;//현재의 업벡터를 기록
            bool jump = Input.GetKey(KeyCode.Space);//점프의 여부 파악
            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));//이동 여부 파악
            
            if ((!anim.GetCurrentAnimatorStateInfo(0).IsName("JUMP00"))||isWater)//점프, 혹은 물속인가?
            {
                if (jump)
                {
                    if (isWater)
                    {
                        if (jumpstyle > 0)
                        {
                            anim.Play("JUMP00");
                            source.PlayOneShot(jumpSound, 1f);
                            rb.AddForce(0, 10, 0, ForceMode.Impulse);
                            jumpstyle--;
                        }
                        Invoke("refillJumpstyle", 0.5f);
                        Debug.Log(jumpstyle);
                    }
                    else { 
                        anim.Play("JUMP00");
                        source.PlayOneShot(jumpSound,1f);
                        rb.AddForce(0, 100, 0, ForceMode.Impulse);
                    }
                }
            }

            bool keydown = Input.GetKey(KeyCode.DownArrow)| Input.GetKey(KeyCode.UpArrow) | Input.GetKey(KeyCode.RightArrow) | Input.GetKey(KeyCode.LeftArrow);//방향키가 눌렸는지 파악
            anyKeyPress = keydown|jump;
                        
            transform.position += move* speed * Time.deltaTime;
            if (keydown) {
                look = move;
                look.y = tempy;
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("JUMP00")) {
                    anim.Play("Locomotion");
                }
            }
            if (anyKeyPress) {
                
                transform.rotation = Quaternion.LookRotation(look);
            }
            look.y = tempy;
            look.y = Mathf.Lerp(look.y, 0, 0.0050f);
        }
    }
    void setWater(bool value)//물에 있는지 파악하는 함수. sendMessage를 통해서 사용
    {
        isWater = value;
        if (isWater)
            jumpstyle = 2;
    }
    void refillJumpstyle()//물속에서 점프 횟수를 충전하는 함수. sendMessage를 통해서 사용
    {
        if(jumpstyle<2)
        {
            jumpstyle+=1;
        }
    }
}
