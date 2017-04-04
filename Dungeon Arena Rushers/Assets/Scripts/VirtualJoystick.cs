using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualJoystick : MonoBehaviour {

	public GameObject Joystick;
	public float Range = 50;

	public static VirtualJoystick Instance;

	//private int TouchID = -1;
	private RectTransform PadPosition;
	private RectTransform StickPosition;
	RectTransform posicion;
	private Vector3 Value;

	void Awake(){
	
		if (FindObjectOfType<VirtualJoystick> () != this) {
		
			Destroy (gameObject);
		
		} else {
		
			Instance = this;
		}
	
	}


	void Start () {

		Joystick.SetActive (false);
		PadPosition = GetComponent<RectTransform> ();
		StickPosition = Joystick.transform.GetChild (0).GetComponent<RectTransform>();
		
	}
	
	// Update is called once per frame
	void Update () {

		MovePad ();
						
	}

	void MovePad(){

		Touch[] toques = Input.touches;
		if (toques.Length > 0) {
			//Hay toque de pantalla
			for (int i = 0; i < toques.Length; i++) {
				//reviso los toques
				if (toques [i].position.x < Screen.width / 2) {
					//si el toque se realizó en el lado izquierdo de la pantalla y está empezando
					//TouchID = toques [i].fingerId;
					if (toques [i].phase == TouchPhase.Began) {
						PadPosition.position = new Vector3 (Input.GetTouch (i).position.x, Input.GetTouch (i).position.y, 0);
						Joystick.SetActive (true);
						break;
					} else if (toques [i].phase == TouchPhase.Moved) {

						//StickPosition.position = new Vector3 (Input.GetTouch (i).position.x, Input.GetTouch (i).position.y, 0);
						StickPosition.position = toques [i].position;
						StickPosition.localPosition = Vector3.ClampMagnitude (StickPosition.localPosition, Range);

						break;
					
					} else if (toques [i].phase == TouchPhase.Stationary) {
						break;				
					}
					else if (toques [i].phase == TouchPhase.Ended || toques [i].phase == TouchPhase.Canceled) {
					
						Joystick.SetActive (false);
						ResetJoystick ();
						break;
					}
				}
			}
		} 

	}

	void ResetJoystick(){
	
		StickPosition.localPosition = Vector3.zero;
	
	}

	public Vector3 GetValue(){

		if (Joystick.activeSelf) {
			Value.Set (ToPercent(StickPosition.localPosition.x, Range, true),0, ToPercent(StickPosition.localPosition.y, Range, true));
			return Value;
		} else
			return Vector3.zero;

	
	}

	float ToPercent(float ammount, float total, bool zeroToOne){

		if (zeroToOne)
			return ammount / total;
		else
			return ammount * 100 / total;
	
	}
}
