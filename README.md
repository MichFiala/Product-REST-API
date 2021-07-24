# Product-REST-API

This project is about creating basic WEB API for getting products, getting product detail and setting product description.

# Storage

It uses localdbfile as SQLite.

For maintaing db structure it uses migrations and seeding data structure.

## Reseeding data:

     cd .\API

     dotnet ef database drop

     Answer y for: Are you sure you want to drop the database 'main' on server 'localdbfile.db'? (y/N)

Data will be seeded after API start

## Running application

     cd .\API

     dotnet watch run

## Testing application

     cd .\Test

     dotnet test


## Note: 

This project had limited time to complete. 

It is missing swagger documentation and versioning due to missing experince in using swagger
      
      
