using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Move : MonoBehaviour
{

    [SerializeField]
    private float walkSpeed;

    [SerializeField]
    private float JumpPower;

    [SerializeField]
    private float lookSensitivity;


    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;

    [SerializeField]
    private Camera theCamera;

    private Rigidbody myRigid;

    public VideoPlayer videoPlayer;

    private bool IsJumping;
    private bool IsLaying= false;
    private Vector3 LayPos;

    private bool isStart = false;


    // Use this for initialization
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        LayPos = new Vector3(0, -0.5f, 0);
        StartCoroutine(WaitAndStart());
    }




    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {

            Moving();
            //Jump();
            CameraRotation();
            CharacterRotation();
            LayDown();

        }
        myRigid.velocity = Vector3.zero;
         myRigid.angularVelocity = Vector3.zero;
    }

    private void Moving()
    {

        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed;

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);


    }



    //private void Jump()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        if (!IsJumping)
    //        {
    //            IsJumping = true;
    //            myRigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
    //        }
    //        else
    //        {
    //            return;
    //        }
    //    }
    //}
    private IEnumerator WaitAndStart()
    {
        yield return new WaitForSeconds(0.6f);
        isStart = true;
    }
    private void LayDown()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(!IsLaying)
            {
                IsLaying = true;
                theCamera.transform.localPosition = LayPos;
            }
            else
            {
                IsLaying = false;
                theCamera.transform.localPosition = Vector3.zero;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            myRigid.AddForce(-transform.forward * 5);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        walkSpeed = 40;
    }


    private void CharacterRotation()
    {
        // 좌우 캐릭터 회전
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
        //Debug.Log(myRigid.rotation);
        //Debug.Log(myRigid.rotation.eulerAngles);
    }

    private void CameraRotation()
    {
        // 상하 카메라 회전
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    private void TvOff()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            videoPlayer.loopPointReached += EndReached;
        }
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
{
    vp.playbackSpeed = vp.playbackSpeed / 10.0F;
}
}