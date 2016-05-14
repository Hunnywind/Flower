using UnityEngine;
using System.Collections;

public class CSeed : MonoBehaviour {
    
    // 바람 방향, 스피드 받으오는 스크립트
    public CWindMgr _cwindMgr;
    
    public float[] _windPower;  // 바람 세기
    private Vector3[] _windDirNomal = new Vector3[8];   //바람 방향

    public Vector3 _preTr;    // 초기 position 값 저장 
    public Quaternion _preQr;  // 초기 rotation 값 저장
    
    private Rigidbody _rigidbody;

    private CFlowerPoolManager cfPoolManager;


    public void SetTr()
    {
        // 재사용을 위해 초기 값 저장
        _preTr = transform.position;
        _preQr = transform.rotation;
    }

    public void Init()
    {
        _rigidbody.isKinematic = true;
        _rigidbody.velocity = Vector3.zero;

        transform.position = _preTr;
        transform.rotation = _preQr;
    }

    public void Spread()
    {
        _rigidbody.isKinematic = false;
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        // 방향 초기화
        WindDirNomalized();
    }

	// Use this for initialization
	void Start () {
        _cwindMgr = GameObject.Find("WindMgr").GetComponent<CWindMgr>();
        cfPoolManager = GameObject.Find("FlowerPoolManager").GetComponent<CFlowerPoolManager>();

        // 재사용을 위해 초기 값 저장
        _preTr = transform.position;
        _preQr = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        // 바람값에 영향 받은 힘 적용
       _rigidbody.AddForce(_windDirNomal[(int)_cwindMgr._windDir] * _windPower[(int)_cwindMgr._windSpeed]);
    }

    // 바람 8방향에 따른 벡터 초기(북쪽부터 시계방향)
    void WindDirNomalized()
    {
        _windDirNomal[0] = new Vector3(0, 0, 1);
        _windDirNomal[1] = new Vector3(1, 0, 1);
        _windDirNomal[1] = _windDirNomal[1].normalized;
        _windDirNomal[2] = new Vector3(1, 0, 0);
        _windDirNomal[3] = new Vector3(1, 0, -1);
        _windDirNomal[3] = _windDirNomal[3].normalized;
        _windDirNomal[4] = new Vector3(0, 0, -1);
        _windDirNomal[5] = new Vector3(-1, 0, -1);
        _windDirNomal[5] = _windDirNomal[5].normalized;
        _windDirNomal[6] = new Vector3(-1, 0, 0);
        _windDirNomal[7] = new Vector3(-1, 0, 1);
        _windDirNomal[7] = _windDirNomal[7].normalized;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Floor")
        {


            Vector3 pos = transform.position;
            pos.y = 0f;
            cfPoolManager.FlowerLevel_Click(6, pos);
            Init();
            gameObject.SetActive(false);
        }
    }
}
