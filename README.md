# CSC 394 - Capstone Project, DePaul Graduation Path

### Website
ASP.NET (C#) Web App.

### Database
Currently using SQLite database, located in \App_Data. This will be replaced by a MySQL(most likely) database. SQL database creation and scripts in \Database.

### Project Requirements
#### UI
> * Student
>   * This is like WhatIf? Plus for graduate SOC MS students. In CS or IS.  It allows a student to test scenarios based on various choices (#classes per quarter, course delivery, etc.)
>   * Student Login/Logout
>   * Student Registration/Edit profile, demographics
>   * Student account deletion
>   * OptIn to responsibilities/agreements
>   * Login password and authentication
>   * Restricted view based on privileges (only your record)
> * Faculty Member (Advisor)
>   * Choose a student
>   * Can then see whatever a student sees
>   * Can do whatever a student does
> * Administrator
>   * Superuser
>   * Login/manage/maintain site
>   * Simulate student or faculty
>   * Access databases
> * Browse courses
>   * Browse degree requirements
>   * Create/edit/delete searches for course or degree requirements
>   * Select/change starting quarter
>   * Select/change degree selection
>   * Select/change number of courses taken per quarter (1,2,3)

#### Logic
> * Path algorithm
>   * Plot optimum shortest path to graduation based on degree, prereqs, quarters classes are offered
>   * If multiple possible courses choices at any point (e.g. choose 1 of the following electives – list them)
>   * If no possible course for a quarter (e.g. 2 course per quarter choice and critical path prereq constraint allows only 1 course, then list the course and flag that student can see advisor for permission.)
>		* SAVE path generated
> * Important decision variables
>	  * Degree program (MS CS or MS IS only)
>		* Concentration
>		* Entering quarter
>		* Number of courses per quarter
>		* Delivery choice– online, classroom, both 
>		* AND from the course descriptions and online syllabus info quarter offered (look at last 2 years)

#### Data
> * Course (available online)
>   * Course #, People Soft #, Description, Prereqs, Quarters offered (check last 2 years -
>   * If it hasn't been offered then mark it as dormant – a problem with electives)
> * Degree (available online)
>   * Course prereq, phase (prereq, advanced, elective, etc)
> * Path
>   * List of course shortest critical path based on prereqs, quarters courses offered, start quarter, 
>   * # courses taking per quarter
> * Others

#### Non-functional
> * Usability/Interface
> * Reliability
> * Performance
> * Implementation
>   * Languages DB etc
> * Delivery
> * Supportability
>   * Skills needed, problems
> * Web Browser support
>   * If web based
> * Device support
> * Legal
>   * Terms of service if any
> * Support Info
>   * How, who
