import { AnyAction, EmptyObject } from '@reduxjs/toolkit'
import { ToolkitStore } from '@reduxjs/toolkit/dist/configureStore'
import { PersistPartial } from 'redux-persist/es/persistReducer'
import { fetchFeaturedProducts, createProduct, editProduct, deleteProduct, fetchAllProducts } from '../../redux/reducer/productReducer'
import { createStore, RootState } from '../../redux/store'
import { CreateProduct, Product } from '../../types/Product'

import productServer from "../shared/productServer"

let store: ToolkitStore<EmptyObject & {
    products: Product[];
    categories: any;
    auth: any;
    cart: any;
    users: any
} & PersistPartial, AnyAction>

beforeAll(() => {
    productServer.listen()
})

afterAll(() => {
    productServer.close()
})

describe("test all the actions", () => {
    test("Should return initial state", () => {
        const store = createStore()
        expect(store.getState().productReducer.length).toBe(0)
    })
    // test("Should fetch all product", async() => {
    //     const selId:any = {
    //         selectedCategory: 2
    //     }
    //     const store = createStore()
    //     await store.dispatch(fetchAllProducts(selId))
    //     expect(store.getState().productReducer.length).toBe(1)
    // })
    test("Should fetch all product", async () => {
        const store = createStore()
        await store.dispatch(fetchFeaturedProducts())
        expect(store.getState().productReducer.length).toBe(5)
    })
    test("Should create product", async () => {
        const newProduct: any = {
            categoryId: 2,
            description: "dddd",
            images: ['https://i.picsum.photos/id/634/200/200.jpg?hmac=3WUmj9wMd1h3UZICk1C5iydU5fixjx0px9jw-LBezgg', ' https://i.picsum.photos/id/634/200/200.jpg?hmac=3WUmj9wMd1h3UZICk1C5iydU5fixjx0px9jw-LBezgg'],
            price: 100,
            title: "Rimmel"
        }
        const store = createStore()
        await store.dispatch(createProduct(newProduct))
        expect(store.getState().productReducer.length).toBe(1)
    })
    test("Should delete product", async () => {
        const pId: any = 1
        const store = createStore()
        await store.dispatch(deleteProduct(pId))
        expect(store.getState().productReducer.length).toBe(0)
    })
    test("should update a product", async () => {
        const product: any = {
            id: 1,
            updateInfo: {
                title: "Anu",
                price: 20,
                description: "Andy shoes are designed to keeping in...",
                images: [
                    "https://placeimg.com/640/480/any?r=0.9178516507833767"]
            }
        }
        const store = createStore()
        await store.dispatch(fetchAllProducts(product))
        await store.dispatch(editProduct(product))
        expect(store.getState().productReducer.length).toBe(5)
        // expect(store.getState().products[0].price).toBe(20)
    })

})