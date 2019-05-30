Towers of Hanoi

Variables and type needed:

gameBoard - dictionary,string, string[]>
inputStart - string //use to capture the column the user wants the top disk from
inputEnd - string //use to capture the column the user wants to move the disk to
movingValue - string //use to move the disk the user identifies
moves - int //use to count the number of moves needed to solve the Towers of Hanoi
test1 - int //the movingValue as an int. use to verify it is smaller than the disk below it on the destination column
test2 - int //the last occupied location on the destination column. use to verify it is larger than the movingValue
tempA - string array
tempB - string array
tempC - string array
solution - string array

i - int //incremental variable
l - int //incremental variable
m - int //incremental variable

In Main:

Use a while loop to print directions, game board, number of moves, and ask the player to select the starting column and ending column. Continue this loop until the user has solved the Towers of Hanoi.

Methods:

bool method gameAction - pass inputStart and inputEnd from Main.

Have an if statement that verifies the player has identified the starting column (inputStart is not null). If inputStart is null, return false and continue the game.

If inputStart is not null:
create new string arrays tempA, tempB, and tempC to use for moving disks and checking for a winner.
populate the arrays with the corresponding gameBoard arrays.
		
For all moves the player makes do the following: (Possible Valid Moves - A -> B, A -> C, B -> A, B -> C, C -> A, C -> B)
Using the appropriate temp array, identify the top most disk (start at 3 and decrement until found).
Set the movingValue variable to match the top most disk.
Using the appropriate temp array, identify the lowest available spot to move the movingValue to.
If the lowest available spot is 0, set it equal to the movingValue and the original spot to null.
If the lowest available spot is greater than 0, set test1 = movingValue, and test2 to the spot one lower than the available spot.
If test1 < test2, set the spot equal to movingValue and the original spot to null.
If test1 > test2, do nothing and return false.
If the disk has been moved break the loops.
Set the gameBoard arrays to equal the temp arrays.
Compare tempC to the solution array. If the match, return true, else return false.	
