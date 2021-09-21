using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	
	public float speed; //tốc độ
	public float energyHave = 100; //tổng energy đang có
	public float dropPlane = 25.0f; //độ drop space
	public float energyReco = 20.0f; //tốc độ khôi phục energy
	public Text energyChange; //đổi số energy hiện có
	public Text pointChange; //thanh đổi điểm thưởng đang có
	public Slider slider; //lấy thông tin thanh energy bar
	public Gradient gradient; //chuyển màu sắc thanh energy bar
	public Image fill; //get ảnh để fill màu
	public Text coolDown;
	public Text coolDownShield;
	public GameObject protextShield;
	
	private Rigidbody2D rb; //main body, player
	private Vector2 moveVelocity;
	private float speedTemplate; //tốc độ hiện tại
	private float speedOrinal; //tốc độ gốc
	private float energyBar; //thanh báo energy
	private EnergyBar energy; //class energy đến từ file EnergyBar
	private int countCollision = 1;
	private int realEnergy; // Energy thật sự hiện tại
	private int pointHave; //Điểm đang có hiện tại
	private Vector2 screenBounds; // screenBounds, khoảng cách giới hạn của screen
	private float tocdo;
	private bool checkShield;
	private float timeforShield = 5.0f;
	private float timeTemp;
	private float countDown = 3.0f;
	private float timeTemp2;
	

	
	
    // Start is called before the first frame update
    void Start()
    {
		checkShield = false;
		timeTemp = 0;
		timeTemp2 = 0;
		
		tocdo = speed;
        rb = GetComponent<Rigidbody2D>();
		
		energy = new EnergyBar(energyHave);
		energyBar = energy.getEnergy();
		
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		
		
		speedTemplate = speed + 7;
		speedOrinal = speed;
		realEnergy = (int) energyHave;
		setMaxEnergy(realEnergy);
    }

    // Update is called once per frame
    void Update ()
	{
		//Debug.Log(timeTemp);
		if (protextShield.activeSelf){
			coolDownShield.text = (int)timeTemp2 + "";
			timeTemp2 = timeTemp2 - Time.deltaTime;
			
		}
		if (timeTemp2 <= 0)  {
			coolDownShield.text = "" + "";
			protextShield.SetActive(false);
		}
		if (timeTemp > 0){
			coolDown.text = (int)timeTemp + "";
			timeTemp = timeTemp - Time.deltaTime;
			
		}
		else if (timeTemp <= 0 ) {
			checkShield = false;
			coolDown.text = "";
		}
		
		
		pointHave = int.Parse(pointChange.text);
		if (pointHave >= 10){
			if (Input.GetKey(KeyCode.Q)) {
				pointChange.text = (pointHave-10) + "";
				rb.gravityScale = 0;
				energy.addEnergy(100);
				speed = tocdo;
				speedTemplate = speed + 7;
				speedOrinal = speed;
				
			}
		}
		else if (pointHave >= 5) {
			if (Input.GetKey(KeyCode.E)) {
				checkShield = true;
				pointChange.text = (pointHave-5) + "";
				timeTemp = timeforShield;
				
			}
			if (Input.GetKey(KeyCode.F) && pointHave >= 7) {
				timeTemp2 = countDown;
				protextShield.SetActive(true);
				pointChange.text = (pointHave-7) + "";
				
			}
		}
		
		energyBar = energy.getEnergy();
		if (energyBar <= 0 )  {
			energyChange.text = "0";
			Debug.Log("YOU DIE");
			rb.gravityScale = dropPlane;
			//Debug.Break();
			
			Vector2 moveInput = new Vector2(0, 0);
			//get key input
			//if A horizon = -1
			//if D horizon = 1
			//if W vertical = 1
			//if S vertical = -1
			moveVelocity= moveInput.normalized * speed;
			Vector3 characterRotate = transform.localScale;
			transform.localScale = characterRotate;
		}
		else {
			energyChange.text = energyBar + "";
			Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
			//get key input
			//if A horizon = -1
			//if D horizon = 1
			//if W vertical = 1
			//if S vertical = -1
			moveVelocity= moveInput.normalized * speed;
			Vector3 characterRotate = transform.localScale;
			transform.localScale = characterRotate;
			
			if (Input.GetKey(KeyCode.Space))
				speed = speedTemplate;
			if (!(Input.GetKey(KeyCode.Space)))
				speed = speedOrinal;
			//add energy use
			if (Input.GetKey(KeyCode.Space)) 
				energy.dropEnergy(4.0f * Time.deltaTime);
			else
				energy.dropEnergy(2.0f * Time.deltaTime);
			//Debug.Log(energyBar);
			
		}
		realEnergy = (int)energy.getEnergy();
		setEnergy(realEnergy);
	}
	
	void FixedUpdate(){
		//all check +x
		if ( rb.position.x + moveVelocity.x * Time.fixedDeltaTime > screenBounds.x )
			if ( rb.position.y + moveVelocity.y * Time.fixedDeltaTime > screenBounds.y)
				rb.MovePosition(new Vector2(screenBounds.x, screenBounds.y));
			else if (rb.position.y + moveVelocity.y * Time.fixedDeltaTime < - screenBounds.y)
				rb.MovePosition(new Vector2(screenBounds.x, screenBounds.y * -1));
			else rb.MovePosition(new Vector2(screenBounds.x, rb.position.y + moveVelocity.y * Time.fixedDeltaTime));
		//all check -x
		else if ( rb.position.x + moveVelocity.x * Time.fixedDeltaTime < -screenBounds.x)
			if ( rb.position.y + moveVelocity.y * Time.fixedDeltaTime > screenBounds.y)
				rb.MovePosition(new Vector2(-screenBounds.x, screenBounds.y));
			else if (rb.position.y + moveVelocity.y * Time.fixedDeltaTime < - screenBounds.y)
				rb.MovePosition(new Vector2(-screenBounds.x, screenBounds.y * -1));
			else rb.MovePosition(new Vector2(-screenBounds.x, rb.position.y + moveVelocity.y * Time.fixedDeltaTime));
		//all check +y
		else if ( rb.position.y + moveVelocity.y * Time.fixedDeltaTime > screenBounds.y )
			rb.MovePosition(new Vector2(rb.position.x + moveVelocity.x * Time.fixedDeltaTime, screenBounds.y));
		//all check -y
		else if ( rb.position.y + moveVelocity.y * Time.fixedDeltaTime < -screenBounds.y)
			rb.MovePosition(new Vector2(rb.position.x + moveVelocity.x * Time.fixedDeltaTime, -screenBounds.y));
		else rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
		//update moi frame, dieu chinh vi tri khi moveVelocity thay doi
		//Time.fixedDeltaTime
	}
	
	private void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Energy"){
			//add energy
			//and destroy after add
			energy.addEnergy(energyReco);
			realEnergy = (int)energy.getEnergy();
			setEnergy(realEnergy);
		}
		else if(other.gameObject.tag == "Coin"){
			pointHave = int.Parse(pointChange.text) + 1;
			pointChange.text = pointHave + "";
			
		}
		else if (other.gameObject.tag == "armo"){}
		else if (other.gameObject.tag == "rock" && checkShield == false){
			//Destroy(this.gameObject); Debug.Break();
			rb.gravityScale = dropPlane + countCollision*10;
			speedTemplate = speedTemplate - 1;
			speedOrinal = speedOrinal - 1;
			}
		
	}
	public void setMaxEnergy(int energyMax){
		slider.maxValue = energyMax;
		slider.value = energyMax;
		
		gradient.Evaluate(1f);
	}
	
	public void setEnergy(int energy){
		slider.value = energy;
		
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
