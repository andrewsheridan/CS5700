# Homework 5 - Andrew Sheridan

I chose to improve the system designed in Programming Assignment 1, because it had no test cases, because my diagrams were terrible, and because I knew of very few patterns when I first implemented the system.



## Diagrams


## System Improvements
I added the Template Method Pattern because I felt it would pair nicely with the strategy pattern. The basic template for this program is to read from a file, use a matching strategy to find matches, then output the results.

The import strategy is automatically chosen based on the file type. The matching strategy is chosen by the user in the UI, as well as the output strategy. When the user clicks `Run`, the program uses the template method pattern to execute all three steps. 

All things related to output have now been pulled out of the GUI and PersonMatcher components. They are now entirely contained in the ExportStrategy Interface and the classes which implement it. This simplifies the GUI significantly, to the point of all event handlers being one to three lines in length. 

I implemented two new export strategies. The first outputs the full names of the two individuals who were deemed "matches". The second outputs all the information of the two matches.

Another added pattern is the Iterator pattern, which is used when outputting all the properties of the two patched persons. Using reflection we make a list of all the properties of the objects, then use the Iterator pattern to loop through them and print them to the console and output file.

## Testing


