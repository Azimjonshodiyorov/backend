# FullStack for E-Commerce Project

Tech stack used for Front-end
- React
- Redux
- Typescript
- Material UI
- SASS
- HTML

Tech stack used for Back-end
- ASP .NET Core
- Entity Framework Core
- PostgreSQL

# Deploy link

Unfortunately backend is not connected with the frontend yet. Still working on that part.

- Frontend: https://fs13-frontend-project-1lpu.vercel.app/
- Backend api(swagger): https://ecommerce-backend.azurewebsites.net/swagger/index.html
- eg: of api endpoints: https://ecommerce-backend.azurewebsites.net/api/v1/products

# Docker image

- Frontend: https://hub.docker.com/repository/docker/anusiraj/frontend/general

## Setting Up for folder `backend`

1. Create `appsettings.json` (and `appsettings.*.json` if needed) file in the root of folder `backend`. You can refer to the content of file `example.json`
2. Dotnet version used here is 7.0. You can change .NET Core version to be compatible with your local machine
3. Install all the needed packages and it should match with the Dotnet version.
    * AutoMapper
    * AutoMapper.Extensions.Microsoft.DependencyInjection
    * EFCore.NamingConventions
    * Microsoft.EntityFrameworkCore
    * Microsoft.EntityFrameworkCore.Design
    * Npgsql.EntityFrameworkCore.PostgreSQL
    * Microsoft.AspNetCore.Mvc.Formatters.Json
    * Microsoft.AspNetCore.OpenApi
    * Microsoft.EntityFrameworkCore.Proxies
    * Swashbuckle.AspNetCore
    * Swashbuckle.AspNetCore.Filters
    * Microsoft.AspNetCore.Authentication.JwtBearer
    * Microsoft.AspNetCore.Identity.EntityFrameworkCore
    * Microsoft.IdentityModel.Tokens
    * System.IdentityModel.Tokens.Jwt



## Endpoints
Includes authentication and authorization, marked endpoints are only available for ADMIN.

1. Products
- GET api/vi/products/filter?
    - api/vi/products/filter?name={name}
    - api/vi/products/filter?price={price}
    - api/vi/products/filter?keyword={keyword}
    - api/vi/products/filter?pricemax={pricemax}&pricemin={pricemin}
    - api/vi/products/filter?categoryId={id}

- POST api/v1/products - FOR ADMIN ONLY
- GET  api/v1/products
- GET  api/v1/products?page={pageno}&itemsperpage={itemsperpage}
- GET  api/v1/products/{id}
- PUT  api/v1/products/{id} - FOR ADMIN ONLY
- DELETE api/v1/products/{id} - FOR ADMIN ONLY

2. Category
- GET  api/v1/categories
- GET  api/v1/categories?page={pageno}&itemsperpage={itemsperpage}
- GET  api/v1/categories/{id}
- POST api/v1/categories - FOR ADMIN ONLY
- GET  api/v1/categories/{id}/products
- PUT  api/v1/categories/{id} - FOR ADMIN ONLY
- DELETE  api/v1/categories/{id} - FOR ADMIN ONLY

3. Image
- GET  api/v1/images
- GET  api/v1/images?page={pageno}&itemsperpage={itemsperpage}
- GET  api/v1/images/{id}
- POST api/v1/images - FOR ADMIN ONLY
- PUT  api/v1/images/{id} - FOR ADMIN ONLY
- DELETE  api/v1/images/{id} - FOR ADMIN ONLY

4. Order
- GET  api/v1/orders - FOR ADMIN & LOGIN-USER ONLY
- GET  api/v1/orders?page={pageno}&itemsperpage={itemsperpage} - FOR ADMIN ONLY
- GET  api/v1/orders/{id} - FOR ADMIN & LOGIN-USER ONLY
- POST  api/v1/orders/{id}/add-products - FOR ADMIN & LOGIN-USER ONLY
- DELETE  api/v1/orders/{id}/remove-product - FOR ADMIN & LOGIN-USER ONLY
- PUT  api/v1/orders/{id}/update-product - FOR ADMIN & LOGIN-USER ONLY
- POST api/v1/orders - FOR ADMIN & LOGIN-USER ONLY
- GET  api/v1/orders/my-orders - FOR ADMIN & LOGIN-USER ONLY    
- PUT  api/v1/orders/{id} - FOR ADMIN ONLY
- DELETE  api/v1/orders/{id} - FOR ADMIN ONLY

5. Role
- POST  api/v1/roles - FOR ADMIN ONLY
- DELETE  api/v1/roles - FOR ADMIN ONLY

6. User
- POST api/v1/users/signup
- POST api/v1/users/signin
- GET api/v1/users/{userid} - FOR ADMIN & LOGIN-USER ONLY
- GET api/v1/users/{email} - FOR ADMIN & LOGIN-USER ONLY
- POST api/v1/users/change-password - FOR LOGIN-USER ONLY
- DELETE api/v1/users/delete/{userid} - FOR ADMIN & LOGIN-USER ONLY
- GET api/v1/users/role - FOR ADMIN & LOGIN-USER ONLY
- GET api/v1/users/all - FOR ADMIN ONLY



## Features planning to develop

1. Endpoint for forgot password
2. Endpoint for reviews
3. Endpoint for wish list
4. Endpoint for customers address
5. Endpoint for checkout
6. Endpoint for tracking status of orders



## Project Structure

```bash
.
├── Program.cs
├── example.json
└── src
    ├── Controllers
    │   ├── ApiControllerBase.cs
    │   ├── CategoryController.cs
    │   ├── CrudController.cs
    │   ├── ImageController.cs
    │   ├── OrderController.cs
    │   ├── ProductController.cs
    │   ├── RoleController.cs
    │   └── UserController.cs
    ├── DTOs
    │   ├── BaseDTO.cs
    │   ├── ICrudFilter.cs
    │   ├── RequestDTO
    │   │   ├── CategoryDTO.cs
    │   │   ├── ImageDTO.cs
    │   │   ├── OrderAddProductsDTO.cs
    │   │   ├── OrderDTO.cs
    │   │   ├── ProductDTO.cs
    │   │   ├── ProductFilterDTO.cs
    │   │   ├── RoleDTO.cs
    │   │   ├── UserSignInDTO.cs
    │   │   └── UserSignUpDTO.cs
    │   └── ResponseDTO
    │       ├── UserSignInResponseDTO.cs
    │       └── UserSignUpResponseDTO.cs
    ├── Db
    │   ├── AppDbContext.cs
    │   ├── AppDbContextSaveChangesInterceptor.cs
    │   └── IdentityConfigExtension.cs
    ├── Helpers
    │   └── ServiceException.cs
    ├── Middlewares
    │   └── ErrorHandlerMiddleware.cs
    ├── Migrations
    │   └── AppDbContextModelSnapshot.cs
    ├── Models
    │   ├── BaseModel.cs
    │   ├── Category.cs
    │   ├── Image.cs
    │   ├── Order.cs
    │   ├── OrderProduct.cs
    │   ├── Product.cs
    │   ├── Role.cs
    │   └── User.cs
    ├── Repositories
    │   ├── CategoryRepo
    │   │   ├── CategoryRepo.cs
    │   │   └── ICategoryRepo.cs
    │   ├── CrudRepo
    │   │   ├── CrudRepo.cs
    │   │   └── ICrudRepo.cs
    │   ├── ImageRepo
    │   │   ├── IImageRepo.cs
    │   │   └── ImageRepo.cs
    │   ├── OrderRepo
    │   │   ├── IOrderRepo.cs
    │   │   └── OrderRepo.cs
    │   └── ProductRepo
    │       ├── IProductRepo.cs
    │       └── ProductRepo.cs
    └── Services
        ├── CategoryService
        │   ├── CategoryService.cs
        │   └── ICategoryService.cs
        ├── CrudService
        │   ├── CrudService.cs
        │   └── ICrudService.cs
        ├── ImageService
        │   ├── IImageService.cs
        │   └── ImageService.cs
        ├── OrderService
        │   ├── IOrderService.cs
        │   └── OrderService.cs
        ├── ProductService
        │   ├── IProductService.cs
        │   └── ProductService.cs
        ├── RoleService.cs
        │   ├── IRoleService.cs
        │   └── RoleService.cs
        ├── TokenService
        │   ├── ITokenService.cs
        │   └── JwtTokenService.cs
        └── UserService
            ├── IUserService.cs
            └── UserService.cs
```


## Entity Relationship Diagram

![App Screenshot](https://i.ibb.co/Cb8BFzY/backend-ERD.png)


## Step for running the project

In the project directory run:-
- dotnet run or 
- dotnet watch












