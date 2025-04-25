## Documentation

**1. Time spent**
- Roughly spent about 1hr30mins on getting the requirements completed, and roughly about another hour
adding a test suite + some styling to the site.

**2. Choice of frontend technology**
- ASP.NET MVC with Razor Views.

**3. Design Choices Taken**
- Used ASP.NET MVC to seperate application logic(Controller), data(Model) and user interface(View).
- Razor views were chosen for their simplicity and tight integration with .NET.
- Data is stored in-memory using a static list of customer objects.
- Input validation is handled with Data Annotations and Controller logic.
  
**4. Issues Found**
- Handling Validation error on the model required some tweaking, meeting the requirement for only 2 decimal places on height required extra logic in the controller.
- I ran into a problem with the button logic in my partial view: having both an OK and a Cancel button caused unexpected behaviour. I originally wanted the cancel button to redirect back to the index page, but having two button elements with different actions led to errors.
- To resolve this, I replaced the Cancel <button> with an a href link styled as a button, which handled redirection without inerferance from form submission logic.

**5. Next steps for Improvement**
- Improve the UI using a front-end framework like Bootstrap.
- Although it was specifically asked for in-memory storage, I would add persistant data storage using Entity Framework with SQLite or SQL Server.
- Utilise JavaScript for improving user experience, such as automatically disabling/enabling the OK button based on real-time form validity.
- Showing and hiding modal dialogs.
- Better Validation feedback.
    
  
