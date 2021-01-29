using UnityEngine;
using System.Collections;

public enum BottleStates
{
    Alive,
    Dead
}

public enum GameplayMode
{
    Runner,
    StaticDump
}

public class BottleTest : MonoBehaviour
{
    public BottleStates bottleState;
    [SerializeField]
    private GameObject Target;
    public Rigidbody rb;
    public float force;
    public float speed = 5.0f;
    private int jumpNo = 0;
    public float Yoffset = 2.0f;

    public bool Rotate;

    public GameManager manager;

    public float RotationSpeed = 30f;

    public static bool AllowInput;

    public bool RotateUp;
    public bool RotateDown;

    public GameObject ActiveBottle;

    public Animator anim;

    public GameplayMode mode = GameplayMode.Runner;

    public ActiveBottle activeBottle;

    public GameObject Bottle;

    public Vector3 OriginalScale;

    public GameObject PlatForm;
    public Vector3 PlatformOriginalScale;

    public float ScaleOffset = 0.3f;

    public string CurrentPlatformName = "None";

    public Vector3 desired;

    public float CoveredDistance;

    public GameObject Particle;

    public float HurdleScaleOffset;

    public float BottleScaleOffset;

    public AudioSource aud;

    public bool OnBasket;

    public GameObject Road;

    public float HurdleSqueezeLimit = 0.4f;

    public float RightOffset = 0.2f;

    void Awake()
    {
        canJump = true;
        AllowInput = false;
         Invoke("EnableInput", 0.8f);
        if (this.Particle)
        {
            this.Particle.SetActive(false);
        }
        this.CoveredDistance = 0.0f;
        this.rb = this.GetComponent<Rigidbody>();
        this.manager = GameObject.FindObjectOfType<GameManager>();
        this.anim = this.ActiveBottle.GetComponent<Animator>();
        this.activeBottle = this.GetComponentInChildren<ActiveBottle>();
        //Invoke("AssignActiveBottle", 0.01f);
    }

    public void EnableInput()
    {
         AllowInput = true;
    }

    public void AssignActiveBottle()
    {
        this.Bottle = this.activeBottle.Bottle;
        this.OriginalScale = this.Bottle.transform.localScale;
    }

    public void AssignTarget(GameObject g)
    {
        this.Target = g;
    }

    public void RD()
    {
        this.RotateDown = true;
      //  this.rb.isKinematic = true;
        CancelInvoke("RD");
    }

    public void MakeItNormal()
    {
        this.rb.isKinematic = false;
        CancelInvoke("MakeItNormal");
    }

    public void RestoreScale()
    {
        this.Bottle.transform.localScale = this.OriginalScale;
        this.PlatForm.transform.localScale = this.PlatformOriginalScale;
        CancelInvoke("RestoreScale");
    }

    public void ResetName()
    {
        this.CurrentPlatformName = "None";
        CancelInvoke("ResetName");
    }

    void Update()
    {
        if (jumpNo < 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //angleChecker();
                //this.rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                //this.transform.rotation = Quaternion.Euler(Vector3.zero);
                Physics.gravity = new Vector3(0, -35f, 0);

                Invoke("ResetName", 0.5f);

                    AddForce();
                    print("1st Jump");
                Invoke("Test", 0.1f);   ////////////////////////////////////////////////////////Test Line
                //this.Particle.SetActive(false);
                //this.RestoreScale();
                Invoke("RD", 0.1f);
                AllowInput = false;
            }
        }

        if (this.rb.velocity.y < 0 & this.RotateDown)
        {
           Physics.gravity = new Vector3(0, -35f, 1);
           this.anim.SetTrigger("FlipDown");
           this.RotateDown = false;
           Debug.Log("Is Not Missing");
           
        }
        

        
    }

    void ApplyForce()
    {
        //AddForce(force, this.desired);
        force = 0;
        this.RotateUp = true;
        this.anim.SetTrigger("FlipUp");
    }

    void ResetRotate()
    {
        this.Rotate = false;
    }

    public void Test()
    {
        //if (this.PlatForm.GetComponent<HurdleSpawner>())
        //    this.PlatForm.GetComponent<HurdleSpawner>().MakeITTrigger();
        CancelInvoke("Test");
    }

    public void FlipUp()
    {
        this.Flip(180);
    }

    public void FlipDown()
    {
        this.Flip(358);
    }

    public void Flip(float RotVal)
    {
        this.ActiveBottle.transform.rotation = Quaternion.Slerp(this.ActiveBottle.transform.rotation, Quaternion.Euler(RotVal, 0, 0), this.RotationSpeed * Time.deltaTime);
    }

    public float ExtraForce;


    public Vector3 bottleForce;
    public bool canJump = true;

    IEnumerator againJump()
    {
        yield return new WaitForSeconds(0.3f);
        canJump = true;
    }

    public void AddForce()
    {

        if (jumpNo <= 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            print("1st");
            this.anim.SetTrigger("FlipUp");
            this.rb.AddForce(200* bottleForce, ForceMode.Acceleration);
            //this.rb.AddTorque(Vector3.right * 9999);
            //ITweenMagic iTM = GetComponent<ITweenMagic>();
            //iTM.initialRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            //if(transform.rotation.x >= 0)
            //    iTM.targetRotation = new Vector3(180, transform.rotation.y, transform.rotation.z);
            //if(transform.rotation.x < 0)
            //    iTM.targetRotation = new Vector3(0, transform.rotation.y, transform.rotation.z);

            //iTM.PlayForwardRotation();
        }
        else
        {
            //transform.eulerAngles = new Vector3(0, 0, 0);
            //this.rb.AddTorque(Vector3.right * 9999);
            this.anim.SetTrigger("FlipUp");
            this.rb.AddForce(200* bottleForce, ForceMode.Acceleration);
            print("2nd");
        }
        canJump = false;
        StartCoroutine(againJump());
        jumpNo++;

    }

    public float RestoreWait = 1.0f;

    void OnCollisionEnter(Collision col)
    {

        //Debug.Log("Ungli " + col.gameObject.name);
        //Physics.gravity = new Vector3(0, -9.81f, 0);
        //this.rb.constraints = RigidbodyConstraints.None;
        this.RotateDown = false;
        this.RotateUp = false;
        if (col.gameObject.tag.Equals("Environment"))
        {

            if (variables.isLevelComplete)
                return;

            this.OnBasket = false;
            if (this.mode.Equals(GameplayMode.StaticDump))
            {
                Invoke("Restore", this.RestoreWait);
                return;
            }
            this.bottleState = BottleStates.Dead;
            this.GameOver();
            this.enabled = false;
        }
        else if (col.gameObject.tag.Equals("Target"))
        {
            Invoke("MoveEnvironment", 0.5f);

            jumpNo = 0;
            this.OnBasket = false;
            this.PlatForm = col.transform.root.gameObject;
            //this.PlatformOriginalScale = new Vector3(1, 1, 1);

            if (this.PlatForm.gameObject.name != this.CurrentPlatformName)
            {
                //this.CoveredDistance += this.GetComponentInChildren<TargetTest>().Distance;
                //if (col.gameObject.name != "SpawnPoint")
                //    Invoke("RegisterFlip", 0.7f);

                //this.CurrentPlatformName = col.gameObject.name;
                //if (this.PlatForm.GetComponentInChildren<UnityEngine.UI.Text>())
                //{
                //    this.PlatForm.GetComponentInChildren<UnityEngine.UI.Text>().transform.parent.gameObject.SetActive(false);
                //}
            }
            Invoke("InputOn", 0.4f);
            //this.anim.SetTrigger("StopAnim");

        }

        else if (col.gameObject.tag.Equals("Basket"))
        {
            PrefsManager.AddToCurrentBottleDumps();
            col.gameObject.GetComponent<SphereCollider>().enabled = false;
            PrefsManager.AddToTotalSuccessFullDumps();
            this.OnBasket = false;
            Debug.Log("In Basket");
            this.manager.AddCoins();
            Invoke("Restore", this.RestoreWait);
        }
        else if (col.gameObject.tag.Equals("BasketMain"))
        {
            this.OnBasket = true;
            Invoke("Check", this.RestoreWait);
        }
    }



    public void Restore()
    {
       // this.PlatForm.GetComponent<CoinProbability>().CheckAndDecide();
        this.manager.RandomizeBaskePosition();
        this.manager.RestoreToLastPosition();
        this.PlatForm.transform.localScale = new Vector3(1, 1, 1);
       // this.PlatForm.GetComponent<SpawnPoint>().Randomize();
      //  this.rb.velocity = Vector3.zero;
         AllowInput = true;
        //this.PlatForm.transform.lossyScale = new Vector3(1, 1, 1);
    }

    void TestAllign()
    {
        if (this.transform.eulerAngles.x < -2 | this.transform.eulerAngles.x > 2)
        {
            Debug.Log("alli");
            //      Invoke("GameOver", 0.5f);
        }
    }

   public void GameOver()
    {
        this.manager.GameOver();
     //   this.gameObject.SetActive(false);
        CancelInvoke("RegisterFlip");
        switch (this.mode)
        {
            case GameplayMode.Runner:
                if (PrefsManager.GetCurrentBottleFlipsCount() > PrefsManager.GetBestBottleFlipCount())
                {
                    PrefsManager.SetBestBottleFlipCount(PrefsManager.GetCurrentBottleFlipsCount());
                }
                break;

            case GameplayMode.StaticDump:
                if (PrefsManager.GetCurrentBottleDumps() > PrefsManager.GetBestBottleDumpCount())
                {
                    PrefsManager.SetBestBottleDumpCount(PrefsManager.GetCurrentBottleDumps());

                    Social.ReportScore((int)(PrefsManager.GetBestBottleDumpCount()), "CgkIkO25l88cEAIQAQ", (bool success) => {
                    });
                }
                this.enabled = false;
                
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "End")
        {
            StartCoroutine(levelComplete());
        }
    }


   IEnumerator levelComplete()
    {
        variables.isLevelComplete = true;
        GetComponent<BottleTest>().enabled = false;
        yield return new WaitForSeconds(2);
        Instantiate(Resources.Load(constants.levelcomplete));
    }

    void Falsify()
    {
        HurdleSpawner.CanCalculate = false;
    }

    void InputOn()
    {
         AllowInput = true;
    }



    void angleChecker()
    {
        Vector3 angle = transform.eulerAngles;
        float x = angle.x;
        float y = angle.y;
        float z = angle.z;

        if (Vector3.Dot(transform.up, Vector3.up) >= 0f)
        {
            if (angle.x >= 0f && angle.x <= 90f)
            {
                x = angle.x;
            }
            if (angle.x >= 270f && angle.x <= 360f)
            {
                x = angle.x - 360f;
            }
        }
        if (Vector3.Dot(transform.up, Vector3.up) < 0f)
        {
            if (angle.x >= 0f && angle.x <= 90f)
            {
                x = 180 - angle.x;
            }
            if (angle.x >= 270f && angle.x <= 360f)
            {
                x = 180 - angle.x;
            }
        }

        if (angle.y > 180)
        {
            y = angle.y - 360f;
        }

        if (angle.z > 180)
        {
            z = angle.z - 360f;
        }

        Debug.Log(angle + " :::: " + Mathf.Round(x) + " , " + Mathf.Round(y)
         + " , " + Mathf.Round(z));
    }



}
