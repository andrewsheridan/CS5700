# Homework 5 - Andrew Sheridan

I chose to improve the system designed in Programming Assignment 1, because it had no test cases, because my diagrams were terrible, and because I knew of very few patterns when I first implemented the system.



## Diagrams


## System Improvements
I added the Template Method Pattern because I felt it would pair nicely with the strategy pattern. The basic template for this program is to read from a file, use a matching strategy to find matches, then output the results.

The import strategy is automatically chosen based on the file type. The matching strategy is chosen by the user in the UI, as well as the output strategy. When the user clicks `Run`, the program uses the template method pattern to execute all three steps. 

All things related to output have now been pulled out of the GUI and PersonMatcher components. They are now entirely contained in the ExportStrategy Interface and the classes which implement it. 

Another improvement is that instead of just outputting the IDs of those who match, there is a strategy for outputting all of the data for the two individuals who were matched side-by-side.

## Testing

