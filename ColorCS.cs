using UnityEngine;
using UnityEngine.UI;

public class ColorCS : MonoBehaviour
{
	public Material mat;
	public Text ssst; //スピードのレベルを表示するText

	private Color color;
	private Color color59;
	private Color color69;
	private Color color79;
	private Color color89;
	private Color color94;
	private Color color99;

	// Use this for initialization
	void Start()
	{
		
	}
	void Update()
	{
		float num = float.Parse(ssst.text);
		//データでの速さをnumにする
		color59 = new Color(1.0F, 0.0F, 0.0F, 1.0F);//赤色。RGBA は (1, 0, 0, 1)
		color69 = new Color(1.0F, 0.0F, 1.0F, 1.0F);//マゼンタ。RGBA は (1, 0, 1, 1)
		color79 = new Color(1.0F, 0.92F, 0.016F, 1.0F);//黄色。RGBA は (1, 0.92, 0.016, 1)
		color89 = new Color(0.0F, 1.0F, 0.0F, 1.0F);//ソリッドグリーン。RGBA は (0, 1, 0, 1)
		color94 = new Color(0.0F, 1.0F, 1.0F, 1.0F);//シアン。RGBA は (0, 1, 1, 1)
		color99 = new Color(0.0F, 0.0F, 0.0F, 1.0F);//黒色。RGBA は (0, 0, 0, 1)

		if (59 >= num)
		{
			color = color59;
		}
		else if (69 >= num)
		{
			color = color69;
		}
		else if (79 >= num)
		{
			color = color79;
		}
		else if (89 >= num)
		{
			color = color89;
		}
		else if (94 >= num)
		{
			color = color94;
		}
		else if (99 >= num)
		{
			color = color99;
		}
		mat.SetColor("_Color", color);
	}
}