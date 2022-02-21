using UnityEngine;

[System.Serializable]
public struct Character
{
	
	public Texture texture;
	public string name;
	[Range (0, 100)] public float speed;
	[Range (0, 10)] public int health;
	public int price;

	public bool isPurchased;
}
