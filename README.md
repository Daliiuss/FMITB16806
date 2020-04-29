V1.0

This program is created to manage students, their lists and their grades.

Functions

1 Output on the screen: 
1.1 Menu window: 

"1 - Enter new students";
"2 - Get students from file";
"3 - Get student list with averages";
"4 - Get student list with mediana";
"5 - Generate student file";
"6 - Group students to file (Strategy 1)";
"7 - Group students to file (Strategy 2)" "-e - exit";

1 "1 - enter new students" option allows user to enter (create) new students. After this option is selected the user will be asked to enter the amount of the students the user wants to add. Then the user must enter students name press return, enter students lastname and press return. After that, the user has an option to fill in random homework grades and random exam grade or it can input it manually. If chosen randomly, the program will generate random grades (from 1-10) for random amount of homework (from 1-100). If user chooses to enter grades manually, the user will be able to enter as much homework grades as the user likes until user types in "-t", which will then allow to enter exam grade.;

2 "2 - get students from file" option allows user to read students from the file with default structure:

Vardas Pavarde ND1 ND2 ND3 ND4 ND5 Egzaminas Vardas1 Pavarde1 8 9 10 6 10 9

After this option is selected, user must enter file directory and press enter. If file is found, it will print out data sheet.

3 option allows user to show averages of entered students (prints out in console the datasheet)

4 option allows user to show mediana of entered students (prints out in console the datasheet) **note user must enter users at first, before choosing 3,4 options

5 Generates student file in selected/typed directory in default pattern Name, Last Name Nd x6, Exam

Since V0.4, fixed in V0.4.1 6 Creates 2 additional lists of bad and good students (full list stays) and then exports them into separate files onto desktop

Since V1.0 7 Creates 1 additional list for bad students and main list becomes list with only good students and then exports them into separate files onto desktop

2, 6, 7 options are measured, after using them, console prints out ram usage and time taken

Strategy analysis

After studying 2 strategies I found out that using Strategy 1, my program works way faster then using Strategy 2. Since I am using List container in my program - 1 Strategy was better, because it takes a lot of time remove entries from list.

This was proven after checking on 3 files (100 000, 1 000 000, 10 000 000) 
Time table: 

Files..........S1.............S2;  

100 000........0:00.246.......0:01.236;  

1 000 000......0:01.156.......0:59.219;  

10 000 000.....0:11.849.......takes way too long  


Memory table: 

Files..........S1.............S2;  

100 000........32407552.......31760384;  

1 000 000......169549824.......162357248;  

10 000 000.....1601216512.......takes way too long;  


S1- strategy 1, S2- strategy 2

After analyzing data. I conluded, that: Yes - strategy 2 is more efficient using memory, but it lacks speed. As strategy 2 might not be as efficient using memory, but it manages to save a lot of time. Probably the poor results of the strategy 1 one might be caused by function that deletes entries from the list. Also, in next version, code should be more optimized.
Instalation:

    Open .exe file.
    Generate files, or enter new students!


Brief Changelog: 
V0.1: 
-Initial state   

V0.2 
-Added read from file   

V0.3 
-implemented several try/catches 
-added few crash preventions and fail-safes   

V0.3.1
-Separation to 3 different files  

V0.4 
-Added sorting to files. -Added file generator  

V0.4.1 
-Functions fixed, read more on V0.4.1 commit   

V0.5 
-tested different methods on containing date within program, stayed with List container. 
-Other versions are available with LinkedList and Queue.
