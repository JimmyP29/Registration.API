# Registration.API
A .NET 8 Minimal Web API project that contains functionality for Registering, Logging in and Retriving persisted users. Please view this as a WIP, the same as with the [Registration.UI](https://github.com/JimmyP29/Registration.UI) project. I have made the decision to give a flavour of coding style and structure, as asked for and have not added things such as tests or validation. As such please let me be clear - __although it runs and works, I would not consider this a complete solution__ let alone a production ready one. 

I hope this is cool.

## Setting Up
The project can be setup once cloned down in Visual Studio by simply running the project from within the IDE. As it is using an in-memory db there are no migrations that need to be run or set up.

## How to use with Swagger

### `GetUsers` (No users)
![GetUsers_no_users](https://github.com/JimmyP29/Registration.API/blob/master/assets/No_Users.gif)

### `RegisterUser` 
![Register_User](https://github.com/JimmyP29/Registration.API/blob/master/assets/Register_User.gif)

### `GetUsers` 
![GetUsers](https://github.com/JimmyP29/Registration.API/blob/master/assets/Get_Users_with_User.gif)

### `LoginUser` (Sad Path)
![LoginUser_sad_path](https://github.com/JimmyP29/Registration.API/blob/master/assets/Login_sad_path.gif)

### `LoginUser` (Happy Path)
![LoginUser_happy_path](https://github.com/JimmyP29/Registration.API/blob/master/assets/Login_happy_path.gif)

## What I have done
I have created a new .NET 8 Web API project and implemented as a Minimal API. This took me a bit of time as I have only used Controllers in the past. I think that I have implemented a solution which is tidy as the endpoints live within the `Api.cs` file as opposed to all being within `Program.cs`. The solution also includes DI which I was unsure at first how to implement without controllers as well. All in all this was a really fun learning experience. :+1:

I have used a DTO as well as a Data Object to facilitate the data flow through the system using service and repository layers, along with their own interfaces to aid in decoupling and improve testability (please see about testing in '__Where this needs improvement in the short term__'). Dependency Injection has been used throughout.

I have kept all business logic in the service layer and away from the endpoints.

I have used an In-Memory Database as asked for.

## Where this needs improvement in the short term
I know that the purpose of this test was to evaluate coding style, approach and decision-making abilities, so I hope you will forgive some quite glaring ommissions and accept my explanation for them here instead. This is all in the interests of time.

- __Testing__: There are no tests in this project. I would plan to have tests for the service layer and repository layers which would mock the dependencies expected of them that have been passed into the constructors. I would test both the happy and sad paths for each method.
- __Validation__: There is also no real validation for the values coming in. I would add this to check for things such as empty strings and valid email address formatting.
- __Mapping__: On line 21 of the `RegistrationSerice` I use a foreach loop to manually map from a `User` object to a `UserDTO` object. I would prefer to use something such as AutoMapper.
- __Security__: There are 2 security concerns here that would be dangerous in a real application, that being the storage of the password as plaintext. I would hash the string within the registration process and store the hash. The second is storing the Token Key within `appsettings.json`. I named it as such to get the point across but IRL this would be stored completely outside the application and passed in using variables.
- __Authorization__: There is no Authorization as requested for the GetUsers endpoint, I spent some time trying to implement `IdentityUser` after I had created my own User classes and implemented the business logic. I admit that when I was researching the implementation I realised that that was probably a mistake and I should have thought about it the other way around. This is because I could have used the `IdentityUser` instead and got a lot of stuff for free, including the Authrization/Authentication. My only concern here is that I couldn't see how to do this using In-Memory database and not a SQL DB instance.

## Future Considerations
- __Scalability__: As a future consideration I would say that this would be kept as a microservice, the incoming traffic would use it for getting JWT tokens for logging and that is it. This could then be horizontally scaled as the User count increased, spinning up new instances of the service.
- __Testability__: As previously mentioned I would have included tests prior to this ever being considered 'done' in a real scenario. I think that my current setup would aid in testability as the flow is vertically sliced for functionality but decoupled within the service and data layers to help with mocking.
- __Maintainability__: I think that the code would be pretty maintainable because of it's uses of interfaces, if we wanted to add a new method to say the service layer then we would have to honour the interface that it implements. If we had different functionality required of us for this service we could easily have created a new service to manage it. Likewise - as mentioned under __Performance__ below, the layers could be interchangeable to use a different service layer of behaviour, and/or a differnt persistance solution all through using the interfaces.
- __Readability__: I think that my solution is quite readable, I would prefer the endpoints to read better and be more RESTful, but I wanted to keep to the brief and wasn't sure how to name them any differently. I prefer readable code as apposed to comments everyhere to allow my work to be self-documenting in that regard. Of course I am biased and would happily welcome any constructive criticism within a PR. Another thing to point out is that I think consistency is hugely important within codebases, so if for example there was something about my code which was inconsistent to the house style, I would change it to match, even if I personally didn't like it in the interests of consistency. A couple of examples of this that spring to mind are:
  - The use of single line `if` statements (and no curly braces) over using the more longform 
  ```c
  if (something) doSomething(); // My preference
  
  if (something) 
  {
    doSomething();
  }
  ```
  - the use of `var` to implicitly declare variables rather than the type itself.
- __Reusability__: I would definitely go back and use `IdentityServer` to implement an `IdentityUser` rather than reinvent the wheel with my User objects. This would be using a real database of some kind anyway so if this was part of an 'Authentication Service', it would be easy to have a small db used just for Users here, using the out-the-box solution. As far as my code is concerned, if the business logic became more complex over time then it would make sense to use more utility methods for pieces of functionality. Perhaps for example the checking of matching strings, this check for matching could be done with Regex that has other rules in it as we see fit. If we wanted to reuse this functionality then it could live in a `DLL` which could be reused as a dependency elsewhere in the system as needed.
 - __Performance__: We could implement a caching layer using something such as Redis for storing Users that have logged back in prior the TTL of their Token has expired. Also if we ever wanted to switch out the database technology for something more performant then we could do so with relative ease using the same `IRegistrationRepository`.

