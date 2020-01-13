# akqa-test

------- requirements --------

Take-away Tech Test

The Task
Develop a web application that performs the following functions:
Capture a person’s name and a number
Convert this number into words
Render this name and number (as words) as a web page.
This is similar in functionality to that of a cheque writing program, for example:
Input: John Smith
“123.45”
Output: John Smith
“ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS”

------- design notes --------

The application is designed to meet the requirements above and below

It is implemented using 
- .NET Core 2.2 Web Api as a back-end
- a simple html page using Ajax call to consume web api as a front-end (index.html)
- a Services class library to implement transformation functionality, it utilizes Humanizr open source library to transform numbers to words
- a Bussiness class library to encapsulate processing/orchestartion logic
- xUnit test project to test services and processing

The back-end of the applicatin is built with extensibility/maintainability in mind. It is structured the way allowing future changes 
without affecting the existing functionality. Using abstractions/interfaces keep parts of the solution decoupled also providing testability.

Please note that the applicationion is build to demonstrate programming skills/style in C#, .NET, Web Api etc so that the front-end of the application
is scarce on purpose.
In a case of a failure the webpage displays raw debug data which is not a good practice for a real life application.
Here it is to demonstrate the data flowing through and available for the client to be consumed the way it finds necessary.


------- more requirements --------

About your solution
Please structure your solution so that it includes :
A web service
A front end application to consume the web service
When implementing the API use any techniques you wish to highlight your skills in building web services.
Please provide:
A solution that can be executed by simply opening the solution file, and running Debug - Start Debugging (or F5) from Visual Studio.
Provide any documentation if additional steps to install or execute are required.
Well documented code.
Well documented Unit Test(s) that provide 100% unit test coverage of all services built. You can use any unit testing framework you feel
comfortable. eg. nUnit, MSTest, xUnit.
Details of applications, frameworks etc. required to run your solution, Technical description and explanation of design and programming
techniques utilized
We are looking for a solution that is:
a working web application using the .NET technology stack,
a site that functions as expected,
an approach that is logical and easy to understand,
code syntax that is readable,
an example of good programming practices & principals, and
able to be run by pressing F5 in Visual Studio, without any additional steps
Please note that:
You should return your work to us once you are satisfied with the quality of your solution within 2-3 days after receiving this exercise for evaluation.
Submitting your solution
Please complete the task as requested by reading the instructions carefully and return your work within 2-3 days.
Please upload the test to
Page 2
A public GitHub or bitbucket repository (and share the repository link with AKQA)
Should you have any questions or concerns regarding this exercise, please do not hesitate to contact the sender via email.
