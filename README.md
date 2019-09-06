# String Calculator interview problem

The final version of this project implements all required questions. It also implements all stretch goals except #2 and #4.

Once the project is built using Visual Studio Code, run the program from the CalculatorApp folder from within the VS Code terminal window.
For example: dotnet run -a -scd=; 1 -ub=1000 "2;3,5,,;0"
Return result: 2+3+5+0+0+0 = 10

Calculator parameters: -<a,s,m,d> -scd=<single custom delimiter> <0,1> -ub=<upper bound> <StringOfValuesToCalculate>
Parameter 1: Math operations (-a = addition, -s = subtraction, -m = multiplication, -d division
Parameter 2 (optional): single custom delimiter
Parameter 3 (optional, defaults to false): 1 = allow negative number, 0 = throw exception for negative number
Parameter 4 (optional): An integer representing the upper bound of the numbers to be calculated. Numbers >= upper bound will be ignored.
Parameter 5: CSV (or alternate delimiter) string of numbers to perform Math operations on


Addition - simply adds all numbers
Subtraction - substracts the numbers from left to right
Multiplication - simply multiple all numbers (zeros count!)
Division - Divides all non-zero numbers from left to right. If a second non-zero number is not found, it returns the one non-zero number in the array.
           In order to keep this simple, this is integer Math so it ignores remainders.