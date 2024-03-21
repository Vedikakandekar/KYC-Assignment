This is solution for problem statement given by KYC360 Company .
Problem Statement is as follows :

This test represents a common request when building an API.
• You need to provide a set of CRUD endpoints for Creating, Reading, Updating, and Deleting Entities.
• You need to provide an endpoint for retrieving a list of Entities, with searching and filtering
capabilities.


Listing entities
Please provide an endpoint to fetch a list of entities.

Single entity
Users would like to be able to retrieve a single entity from the API. Please provide an endpoint to fetch an
entity by id.


Searching entities
Users would now like to be able to search across the entities using the API. Your endpoint for fetching a list
of entities will need to support searching for entities through the following fields:
• Address Country
• Address Line
• FirstName
• MiddleName
• Surname
If a user was to call your endpoint and provide a ?search=bob%20smith query parameter, your endpoint will
return any entities where the text bob smith exists in any of the fields listed above.


Advanced filtering
The users would now like the ability to filter entities. Your endpoint for fetching a list of entities will need to
support filtering 
using the following optional query parameters:
Parameter Description
gender Gender of the entity.
startDate The start date for the Dates.Date field.
endDate The end date for the Dates.Date field.
countries 0 or more countries for Addresses.AddressCountry field
All start and end dates are inclusive (e.g. startDate=2000-01-01&endDate=2000-12-31 will return 2000-01-01
<= Dates.Date <= 2000-12-31).



Solution : 

There are following endpoints To work with Entities :

1. Endpoint TO get ALL Entities
   This is get request.
     Sample URL : https://localhost:44339/kyc/entities/getAll
     method     : Get
     Body       : None
      

3. Endpoint TO get Entity by ID
   This is get request.
     Sample URL : https://localhost:44339/kyc/entities/id
     method     : Get
     Body       : None

   
5. Endpoint TO create new Entity
   This is Post request.
     Sample URL : https://localhost:44339/kyc/entities/create
     method     : Post
     Body       :  {
        "id": "1",
        "names": [
            {
                "firstName": "reshma",
                "middleName": "vinayak",
                "surname": "salake"
            }
        ],
        "addresses": [
            {
                "addressLine": "warje",
                "city": "pune",
                "country": "India"
            }
        ],
        "dates": [
            {
                "dateType": "dob",
                "dateValue": "2001-11-20T15:30:00"
            }
        ],
        "deceased": false,
        "gender": "Female"
    }


4.Endpoint TO search  Entities by address or Name
     Sample URL : https://localhost:44339/kyc/entities/search?searchTerm=value
     method     : Get
     Body       : None

5.Endpoint TO filter  Entities on the basis of gender , country & dates
     Sample URL : https://localhost:44339/kyc/entities/filter?country=value&gender=value2
     method     : Get
     Body       : None
     country and gender can't be null.


