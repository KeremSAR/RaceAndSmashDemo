using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using MoreMountains.NiceVibrations;
public class SettingsMenu : MonoBehaviour
{
	[Header ("space between menu items")]
	[SerializeField] Vector2 spacing;

	[Space]
	[Header ("Main button rotation")]
	[SerializeField] float rotationDuration;
	[SerializeField] Ease rotationEase;

	[Space]
	[Header ("Animation")]
	[SerializeField] float expandDuration;
	[SerializeField] float collapseDuration;
	[SerializeField] Ease expandEase;
	[SerializeField] Ease collapseEase;

	[Space]
	[Header ("Fading")]
	[SerializeField] float expandFadeDuration;
	[SerializeField] float collapseFadeDuration;

	Button mainButton;
	SettingsMenuItem[] menuItems;

	//is menu opened or not
	bool isExpanded = false;

	Vector2 mainButtonPosition;
	int itemsCount;
	
	public GameObject  gSoundOn, gSoundOff, gVibrateOn, gVibrateOff;

	
	private void OnEnable()
	{
		ChangeSprite();
	}
	
	
	void Start ()
	{
		
		//add all the items to the menuItems array
		itemsCount = transform.childCount - 1;
		menuItems = new SettingsMenuItem[itemsCount];
		for (int i = 0; i < itemsCount; i++) {
			// +1 to ignore the main button
			menuItems [i] = transform.GetChild (i + 1).GetComponent <SettingsMenuItem> ();
		}

		mainButton = transform.GetChild (0).GetComponent <Button> ();
		mainButton.onClick.AddListener (ToggleMenu);
		//SetAsLastSibling () to make sure that the main button will be always at the top layer
		mainButton.transform.SetAsLastSibling ();

		mainButtonPosition = mainButton.transform.position;

		//set all menu items position to mainButtonPosition
		ResetPositions ();
	}

	private void ChangeSprite() {
		ChangeSoundSprite();
		//ChangeMusicSprite();
		ChangeVibrateSprite();
	}
	void ResetPositions ()
	{
		for (int i = 0; i < itemsCount; i++) {
			menuItems [i].trans.position = mainButtonPosition;
		}
	}

	void ToggleMenu ()
	{
		isExpanded = !isExpanded;

		if (isExpanded) {
			//menu opened
			for (int i = 0; i < itemsCount; i++) {
				menuItems [i].trans.DOMove (mainButtonPosition + spacing * (i + 1), expandDuration).SetEase (expandEase);
				//Fade to alpha=1 starting from alpha=0 immediately
				menuItems [i].img.DOFade (1f, expandFadeDuration).From (0f);
			}
		} else {
			//menu closed
			for (int i = 0; i < itemsCount; i++) {
				menuItems [i].trans.DOMove (mainButtonPosition, collapseDuration).SetEase (collapseEase);
				//Fade to alpha=0
				menuItems [i].img.DOFade (0f, collapseFadeDuration);
			}
		}

		//rotate main button arround Z axis by 180 degree starting from 0
		mainButton.transform
			.DORotate (Vector3.forward * 180f, rotationDuration)
			.From (Vector3.zero)
			.SetEase (rotationEase);
	}

	public void OnItemClick (int index)
	{
		//here you can add you logic 
		switch (index) {
			case 0: 
				//first button
				Debug.Log ("Music");
				break;
			case 1:
				//GameObject.Find("CameraParent").GetComponent<AudioSource>().enabled = false;
				
			
				Debug.Log ("Sounds");
				break;
			case 2: 
				//third button
			
			
				Debug.Log ("Vibration");
				break;
		}
	}

	private bool isSoundOn;
	public void ChangeSound() {
		isSoundOn = !isSoundOn;
		ChangeSoundSprite();
		AudioListener.pause = !AudioListener.pause;
		
	}

	private bool isVibrateOn;
	public void ChangeVibrate() {
		isVibrateOn = !isVibrateOn;
		ChangeVibrateSprite();
		MMVibrationManager.SetHapticsActive(isVibrateOn);
	}
	
	private void ChangeVibrateSprite() {
		gVibrateOff.SetActive(!isVibrateOn);
		gVibrateOn.SetActive(isVibrateOn);
	}
	private void ChangeSoundSprite() {
		gSoundOff.SetActive(!isSoundOn);
		gSoundOn.SetActive(isSoundOn);
	}
	
	
	

	public void OnDestroy ()
	{
		//remove click listener to avoid memory leaks
		mainButton.onClick.RemoveListener (ToggleMenu);
	}
}