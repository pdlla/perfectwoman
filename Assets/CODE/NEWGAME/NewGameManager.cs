using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public enum GameState
{
	NONE,PLAY,CUTSCENE,DEATH,CHOICE,TRANSITION,GRAVE
}

public class NewGameManager : FakeMonoBehaviour
{
    public NewGameManager(ManagerManager aManager)
        : base(aManager) 
    {
    }
	public TimedEventDistributor TED { get; private set; }
	
	//TODO implement this or delete
	public int CurrentLevel
    { get; private set; }
	
	public CharacterLoader CurrentCharacterLoader
	{ get; private set; }
	
	public GameState GS
	{ get; private set; }
	
	public float TotalScore{ 
		get{
			return mPerformanceStats.Sum(delegate (PerformanceStats e) { return e.Score; });
		}
	}
	
	public PerformanceStats CurrentPerformanceStat
	{ get { return mPerformanceStats[mPerformanceStats.Count-1]; } }
	
	
	//actual game data
	List<PerformanceStats> mPerformanceStats = new List<PerformanceStats>();
	
	public override void Start()
	{
		CurrentCharacterLoader = null;
		GS = GameState.NONE;
		TED = new TimedEventDistributor();
		
		//TODO initialize game state
			//start in on loading screen
			//interfaceManager -> loading screen ...
		
		//TODO buffer grave
		
		//initialize game data
		//initialize_fetus();
	
	}
	
	public void initialize_fetus()
	{
		mManager.mAssetLoader.new_load_character("0-1",mManager.mCharacterBundleManager);
		
		
	}
	
	public void initialize_choice(int choiceIndex)
	{
		//TODO	
	}
	
	public void initialize_grave()
	{
		mManager.mAssetLoader.new_load_character("999",mManager.mCharacterBundleManager);
	}
	
	public void character_changed_listener(CharacterLoader aCharacter)
	{
		//at this point, we can assume both body manager, music and background managers have been set accordingly
		//i.e. this is part of transition to PLAY or GRAVE
		CurrentCharacterLoader = aCharacter;
		
		//set new character data
		mPerformanceStats.Add(new PerformanceStats());
		CurrentPerformanceStat.Character = new CharacterIndex(aCharacter.Name);
		
		//TODO
		switch(aCharacter.Name)
		{
			case "0-1":
				break;
			case "100":
				break;
			case "999":
				break;
			default:
				break;
		}
	}
    
	
	
    public override void Update()
    {
        //User = (mManager.mZigManager.has_user());
		
		if(GS == GameState.PLAY)
			update_PLAY();
        
		TED.update(Time.deltaTime);
	}
	
	public float TimeRemaining
	{ get; private set; }
	public float TimeTotal
	{ get; private set; }
	public float PercentTimeCompletion
	{ get { return TimeRemaining/TimeTotal; } }
	public ProGrading.Pose CurrentTargetPose
    { get; private set; }
	
	public void update_PLAY()
	{
		TimeRemaining -= Time.deltaTime;
		
		if (CurrentTargetPose != null && mManager.mTransparentBodyManager.mFlat.mTargetPose != null)
        {
            //float grade = ProGrading.grade_pose(CurrentPose, mManager.mTransparentBodyManager.mFlat.mTargetPose);
			//TODO update interface with percent completion
			//PercentTimeCompletion
			
			//TODO update score
			//CurrentPerformanceStat.Score
        }
		
		if(TimeRemaining < 0)
		{
			update_PLAY();
			transition_to_CUTSCENE();
		}
	}
	public void finish_PLAY()
	{
	}
	
	public void transition_to_CUTSCENE()
	{
		GS = GameState.CUTSCENE;
		mManager.mInterfaceManager.set_for_CUTSCENE(
			delegate() { transition_to_CHOICE(); }
		);
		
		//TODO check if cutsceen exsits...
		mManager.mBackgroundManager.load_cutscene(0,CurrentCharacterLoader);
	}
	
	public void transition_to_DEATH()
	{
		GS = GameState.DEATH;	
		//mManager.mInterfaceManager
		//mManager.mBackgroundManager
		//TODO get grave cutscene stuff..
		//initialize_grave();
	}
	
	public void transition_to_CHOICE()
	{
		GS = GameState.CHOICE;
		mManager.mInterfaceManager.set_for_CHOICE();	
	}
	
	public void transition_to_PLAY()
	{
		//mManager.mInterfaceManager.set_for_PLAY();
	}
	
	public void transition_to_TRANSITION_play()
	{
		GS = GameState.TRANSITION;
		//mManager.mTransitionCameraManager.fade
	}
	
	public void transition_to_TRANSITION_grave()
	{
		GS = GameState.TRANSITION;
		//mManager.mTransitionCameraManager.fade
	}
	
	public void transition_to_GRAVE()
	{
		GS = GameState.GRAVE;
		//TODO
	}
	
	public void cleanup()
	{
		//TODO
	}
	
	public void hack_choice(int choice, float time = -1)
	{
		//TODO
	}
    
}
