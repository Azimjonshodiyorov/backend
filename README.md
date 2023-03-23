# FullStack for E-Commerce Project

This project contains both Front-end and Back-end.

Tech stack used for Front-end
- React
- Redux
- Typescript
- Material UI
- SASS
- HTML

frontend deploy link: https://fs13-frontend-project-1lpu.vercel.app/

Tech stack used for Back-end
- ASP .NET Core
- Entity Framework Core
- PostgreSQL


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
- GET  api/v1/orders
- GET  api/v1/orders?page={pageno}&itemsperpage={itemsperpage}
- GET  api/v1/orders/{id}
- POST  api/v1/orders/{id}/add-products
- DELETE  api/v1/orders/{id}/remove-product
- PUT  api/v1/orders/{id}/update-product
- POST api/v1/orders
- GET  api/v1/orders/username
- PUT  api/v1/orders/{id} - FOR ADMIN ONLY
- DELETE  api/v1/orders/{id} - FOR ADMIN ONLY

5. Role
- POST  api/v1/roles - FOR ADMIN ONLY
- DELETE  api/v1/roles - FOR ADMIN ONLY

6. User
- POST api/v1/users/signup
- POST api/v1/users/signin
- GET api/v1/users/{userid}
- GET api/v1/users/email
- POST api/v1/users/change-password
- DELETE api/v1/users/delete/{userid}
- GET api/v1/users/role
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
├── Properties
│   └── launchSettings.json
├── appsettings.Development.json
├── appsettings.Production.json
├── appsettings.json
├── backend.csproj
├── bin
│   └── Debug
│       └── net7.0
│           ├── AutoMapper.Extensions.Microsoft.DependencyInjection.dll
│           ├── AutoMapper.dll
│           ├── Castle.Core.dll
│           ├── EFCore.NamingConventions.dll
│           ├── Humanizer.dll
│           ├── Microsoft.AspNetCore.Authentication.JwtBearer.dll
│           ├── Microsoft.AspNetCore.Identity.EntityFrameworkCore.dll
│           ├── Microsoft.AspNetCore.JsonPatch.dll
│           ├── Microsoft.AspNetCore.OpenApi.dll
│           ├── Microsoft.EntityFrameworkCore.Abstractions.dll
│           ├── Microsoft.EntityFrameworkCore.Design.dll
│           ├── Microsoft.EntityFrameworkCore.Proxies.dll
│           ├── Microsoft.EntityFrameworkCore.Relational.dll
│           ├── Microsoft.EntityFrameworkCore.dll
│           ├── Microsoft.Extensions.DependencyModel.dll
│           ├── Microsoft.IdentityModel.Abstractions.dll
│           ├── Microsoft.IdentityModel.JsonWebTokens.dll
│           ├── Microsoft.IdentityModel.Logging.dll
│           ├── Microsoft.IdentityModel.Protocols.OpenIdConnect.dll
│           ├── Microsoft.IdentityModel.Protocols.dll
│           ├── Microsoft.IdentityModel.Tokens.dll
│           ├── Microsoft.OpenApi.dll
│           ├── Mono.TextTemplating.dll
│           ├── Newtonsoft.Json.dll
│           ├── Npgsql.EntityFrameworkCore.PostgreSQL.dll
│           ├── Npgsql.dll
│           ├── Scrutor.dll
│           ├── Swashbuckle.AspNetCore.Filters.Abstractions.dll
│           ├── Swashbuckle.AspNetCore.Filters.dll
│           ├── Swashbuckle.AspNetCore.Swagger.dll
│           ├── Swashbuckle.AspNetCore.SwaggerGen.dll
│           ├── Swashbuckle.AspNetCore.SwaggerUI.dll
│           ├── System.CodeDom.dll
│           ├── System.IdentityModel.Tokens.Jwt.dll
│           ├── appsettings.Development.json
│           ├── appsettings.Production.json
│           ├── appsettings.json
│           ├── backend
│           ├── backend.deps.json
│           ├── backend.dll
│           ├── backend.pdb
│           ├── backend.runtimeconfig.json
│           ├── example.json
│           └── runtimes
│               └── win
│                   └── lib
│                       └── net6.0
│                           └── System.Diagnostics.EventLog.Messages.dll
├── example.json
├── obj
│   ├── Debug
│   │   └── net7.0
│   │       ├── apphost
│   │       ├── backend.AssemblyInfo.cs
│   │       ├── backend.AssemblyInfoInputs.cache
│   │       ├── backend.GeneratedMSBuildEditorConfig.editorconfig
│   │       ├── backend.GlobalUsings.g.cs
│   │       ├── backend.MvcApplicationPartsAssemblyInfo.cache
│   │       ├── backend.MvcApplicationPartsAssemblyInfo.cs
│   │       ├── backend.assets.cache
│   │       ├── backend.csproj.AssemblyReference.cache
│   │       ├── backend.csproj.CopyComplete
│   │       ├── backend.csproj.CoreCompileInputs.cache
│   │       ├── backend.csproj.FileListAbsolute.txt
│   │       ├── backend.dll
│   │       ├── backend.genruntimeconfig.cache
│   │       ├── backend.pdb
│   │       ├── project.razor.json
│   │       ├── ref
│   │       │   └── backend.dll
│   │       ├── refint
│   │       │   └── backend.dll
│   │       ├── staticwebassets
│   │       │   ├── msbuild.build.backend.props
│   │       │   ├── msbuild.buildMultiTargeting.backend.props
│   │       │   └── msbuild.buildTransitive.backend.props
│   │       └── staticwebassets.build.json
│   ├── backend.csproj.EntityFrameworkCore.targets
│   ├── backend.csproj.nuget.dgspec.json
│   ├── backend.csproj.nuget.g.props
│   ├── backend.csproj.nuget.g.targets
│   ├── project.assets.json
│   └── project.nuget.cache
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
    │   ├── 20230313194640_AddIdentitySupport.Designer.cs
    │   ├── 20230313194640_AddIdentitySupport.cs
    │   ├── 20230314080531_AddIdentitySupport1.Designer.cs
    │   ├── 20230314080531_AddIdentitySupport1.cs
    │   ├── 20230315102256_UserChanges.Designer.cs
    │   ├── 20230315102256_UserChanges.cs
    │   ├── 20230316205554_CartTable.Designer.cs
    │   ├── 20230316205554_CartTable.cs
    │   ├── 20230317141355_CartToOrderRename.Designer.cs
    │   ├── 20230317141355_CartToOrderRename.cs
    │   ├── 20230317174050_UserOrderRelation.Designer.cs
    │   ├── 20230317174050_UserOrderRelation.cs
    │   ├── 20230319080925_ChangeInOrderTable.Designer.cs
    │   ├── 20230319080925_ChangeInOrderTable.cs
    │   ├── 20230319113139_RefactoringOrder.Designer.cs
    │   ├── 20230319113139_RefactoringOrder.cs
    │   ├── 20230319114849_RefactoringOrder1.Designer.cs
    │   ├── 20230319114849_RefactoringOrder1.cs
    │   ├── 20230319124613_OrderModelRefactoring.Designer.cs
    │   ├── 20230319124613_OrderModelRefactoring.cs
    │   ├── 20230323094316_Productvalidation.Designer.cs
    │   ├── 20230323094316_Productvalidation.cs
    │   ├── 20230323110104_ValidationAttributes.Designer.cs
    │   ├── 20230323110104_ValidationAttributes.cs
    │   ├── 20230323111221_ValidationAttributesChanges.Designer.cs
    │   ├── 20230323111221_ValidationAttributesChanges.cs
    │   ├── 20230323112817_ValidationAttributesChanges1.0.Designer.cs
    │   ├── 20230323112817_ValidationAttributesChanges1.0.cs
    │   ├── 20230323115324_REAFCTORINGValidationAttributesChanges.Designer.cs
    │   ├── 20230323115324_REAFCTORINGValidationAttributesChanges.cs
    │   ├── 20230323121522_ChangingRoutes.Designer.cs
    │   ├── 20230323121522_ChangingRoutes.cs
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












