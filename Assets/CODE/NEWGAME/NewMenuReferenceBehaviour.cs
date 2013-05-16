using UnityEngine;
using System.Collections;

public class NewMenuReferenceBehaviour : MonoBehaviour {
	
	//generic
	public Texture2D genericFontTex;
	public int genericFontTexWidth;
	public Font genericFont;
	
	//configurator logos
	public Texture2D gameLabLogo;
	public Texture2D filmAkademieLogo;
	
	//ui
	public Texture2D uiPerfectStar;
	public GameObject uiParticlePrefab;
	
	//blue bar
	public Texture2D bbBackground;
	public Texture2D bbGraphBackground;
	public Texture2D bbGraphFrame;
	public Texture2D bbGraphDot;
	public Texture2D bbScoreBackground;
	
	//choice
	public Texture2D bbChoiceBox;
	public Texture2D bbChoiceFrame;
	public Texture2D[] bbChoicePerfectIcons;
	
	//pink bar
	public Texture2D pbBackground;
	public Texture2D pbCharacterIconBackground;
	
	
	//text
	public Texture2D[] textSmallBubble;
	
	//audio
	public AudioClip transitionIn;
	public AudioClip transitionOut;
	public AudioClip choiceBlip; //played when your selection changes
	public AudioClip choiceMade; //played when selection is made
	public AudioClip choiceMusic;
	public AudioClip graveAngel;
	//TODO more
	
}
