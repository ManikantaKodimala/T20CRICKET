# T20CRICKET
This is a C# console Application. This application is about cricket score prediction based on the bowling style , batting style and timing of shot.
# **Asumptions**

* Here each innings has 20 balls and 10 wickets.
* This app supports 10 types of Ball{"Bouncer", "InSwinger", "OutSwinger", "OffCutter", "Yorker", "OffBreak", "LegCutter", "SlowerBall", "Pace", "Doosra"}
* For each type of ball a player can select a shot from available shots {"Straight","CoverDrive","Sweep","Pull","UpperCut","Scoop","SquareCut","LongOn","LegLance","Flick"}
* We have only four batting times {"Early","Good","Perfect","Late"}
* When ever there is a tie , we are going to have Super over(with six balls and 2 wickets).
#  **To Run the App**
```
 $ dotnet run
```
# **Input Guidelines**
### For Normal Innings
* We need to provide the input in the following format
* Bowling_type Shot_selected Shot_timing
#### Ex:-
>Bouncer Pull Perfect
## Note:
* Input must be given in the same formate and spellings must follow Camel case format as provided above.
### For Super Over 
* When we are going to play Super Over , user is provided with 6 bowling types which is going to be selected inorder.
* User need to provide only Batting style and timing.
#### Ex:-
> Pull Good
