
# Lu-Lu (E-commerce website)

Lu-Lu is an e-commerce website made with React-Redux,Typescript, Material UI and SASS

# Deploy link

Live link: https://fs13-frontend-project-1lpu.vercel.app/

# Requirements

1. API endpoint for fetching datas - [https://fakeapi.platzi.com/](https://fakeapi.platzi.com/)
2. Pages for the website 
   - Home pages
   - Products page
   - Single product page
   - Profile page
   - Cart page
3. Modals
   - For add product
   - For Edit product
   - For edit Profile
   - For delete Profile

# Technologies 

- React
- Redux
- Typescript
- Material UI
- SASS

# Features

## For User
 
- Home page with featured products and their details when clicking.
- Entire Products page
- Entire details of choosen products
- Can sort products by price, search by prducts name, search products by category
- User needs to Login or Register account to add items to cart.
- Profile page
- Modify and Delete their account from profile page.
- Redux store is persisted using Redux Pesist, reload do not affects login and cart items.

## For Admin

- Only admin can Add, Modify and Delete product.

## Screenshots

Home Pages before Login

![App Screenshot](https://i.ibb.co/Tq4rSst/Home1.png)

![App Screenshot](https://i.ibb.co/fxNcsXw/Home2.png)

Product pages before and after Login

Before Login

![App Screenshot](https://i.ibb.co/LNKN5Xb/Product1.png)
![App Screenshot](https://i.ibb.co/9twYM8c/Product2.png)

After Login

![App Screenshot](https://i.ibb.co/W2hRWcv/Screenshot-2023-01-13-at-10-27-04-AM.png)

Single Product Page

![App Screenshot](https://i.ibb.co/yBSpddW/single-Product.png)

Login Page

![App Screenshot](https://i.ibb.co/PQ0gkHM/Login.png)

Cart Page

![App Screenshot](https://i.ibb.co/J3T7YMy/Cart.png)

Profile page

![App Screenshot](https://i.ibb.co/4VcPYdT/UProfile.png)

Admin Page

![App Screenshot](https://i.ibb.co/ygrc7m7/admin.png)

## Future features

- Wish List for users
- Reviewing products
- Facke Chekout and Place orders
- Animation on Product card and buttons

# Project Structure

```bash
├── public
│   ├── assets
│   │   ├── hero1.jpg
│   │   ├── hero2.jpg
│   │   └── hero3.jpg
│   ├── favicon.ico
│   ├── index.html
│   ├── logo192.png
│   ├── logo512.png
│   ├── manifest.json
│   └── robots.txt
├── src
│   ├── App.tsx
│   ├── Style.css
│   ├── components
│   │   ├── Auth.tsx
│   │   ├── CartComponent.tsx
│   │   ├── EntryPageComponent.tsx
│   │   ├── FooterComponent.tsx
│   │   ├── HeaderComponent.tsx
│   │   ├── LoadingtoRedirectComponent.tsx
│   │   ├── PrivateRouteComponent.tsx
│   │   ├── ProductComponent.tsx
│   │   ├── cartPage.tsx
│   │   ├── homeComponent.tsx
│   │   ├── pagination.tsx
│   │   └── profileComponent.tsx
│   ├── hooks
│   │   ├── customHooks
│   │   └── reduxHook.ts
│   ├── index.tsx
│   ├── pages
│   │   ├── createProduct.tsx
│   │   ├── deleteUserAccount.tsx
│   │   ├── editProduct.tsx
│   │   ├── editProfileForm.tsx
│   │   └── review.tsx
│   ├── react-app-env.d.ts
│   ├── redux
│   │   ├── reducer
│   │   └── store.ts
│   ├── reportWebVitals.ts
│   ├── services
│   │   └── authApi.ts
│   ├── setupTests.ts
│   ├── styles
│   │   ├── section
│   │   ├── shared
│   │   └── style.scss
│   ├── test
│   │   ├── reducers
│   │   └── shared
│   └── types
│       ├── Auth.ts
│       ├── Cart.ts
│       ├── Category.ts
│       └── Product.ts
├── tsconfig.json
├── yarn-error.log
└── yarn.lock
```

#Setup and running instruction

Go to the project folder where you want to create application.

1. npm install
     or
   yarn install
2. npx create-react-app <project-name> --template redux-typescript
3. npm install @mui/material
      or yarn add @mui/material
4. npm i sass or yarn add sass
5. npm start or yarn start

# Getting Started

Clone the repository from github: git clone

