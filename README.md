# AND-Test
PhneNumbers API example

The API assembly is hosted on azure web app which is being called through:
https://app.swaggerhub.com/apis-docs/A9689/and-digital_test/v1 where you can notice that client code and API definition are generated with Swagger. However you can test API endpoints directly to http://andphonenumberstest.azurewebsites.net/

## Design Note:
Customer model and controller are not developed in the solution as the main focus is on phone number model and requirements don't include any endpoint to deal with customers. Phone Number entity has foreign key to the related customer id alongisde its other fields. If customer was needed to be represented or client need to call any API endpoint with customer name not ID, then customer model will be needed and should have also a list of phone numbers to represent the 1:N relationship. for the purpose of this test, API is called with the unique id of phone number or customer.

Thanks




