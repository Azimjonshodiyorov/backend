import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit";
import axios, { AxiosResponse } from "axios";

import { CreateProduct, Product } from "../../types/Product";

const initialState: Product[] = []
export const fetchAllProducts = createAsyncThunk(
    "fetchAllProducts",
    async (payload: {selectedCategory : number}) => {
        const { selectedCategory } = payload;
        if(selectedCategory>1) {
            try {
            const jsondata = await fetch(`https://api.escuelajs.co/api/v1/categories/${selectedCategory}/products`)
            const data:Product[]|Error = await jsondata.json()
            return data
            } catch (e: any) {
                console.log(e)
            }
        }
        else{
            try {
                const jsondata = await fetch(`https://api.escuelajs.co/api/v1/products`)
                const data:Product[]|Error = await jsondata.json()
                return data
                } catch (e: any) {
                    console.log(e)
                }
        }
    }
)
export const fetchFeaturedProducts = createAsyncThunk(
    "fetchFeaturedProducts",
    async () => {
            try {
                const jsondata = await fetch(`https://api.escuelajs.co/api/v1/products?offset=0&limit=12`)
                const data:Product[]|Error = await jsondata.json()
                return data
                } catch (e: any) {
                    console.log(e)
                }
        }
)
export const createProduct = createAsyncThunk(
    "createProduct",
    async (product: CreateProduct) => {
        console.log("Product Gotte in reducer is",product)
        try {
            const response: AxiosResponse<Product, Product> = await axios.post("https://api.escuelajs.co/api/v1/products/", product)
            return response.data
        } catch (e) {
            console.log(e)
        }
    }
)
export const editProduct = createAsyncThunk(
    "editProduct",
    async (payload: CreateProduct) => {
        console.log("edit Product details", payload)
        try {
            const response: AxiosResponse<Product, Product> = await axios.put(`https://api.escuelajs.co/api/v1/products/${payload.id}`, payload)
            return response.data
        } catch (e) {
            console.log(e)
        }
    }
)
export const deleteProduct = createAsyncThunk(
    "deleteProduct",
    async (payload: {id: number}) => {
        try {
            const response: AxiosResponse<Product, any> = await axios.delete(`https://api.escuelajs.co/api/v1/products/${payload.id}`)
            return response.data
        } catch (e) {
            console.log(e)
        }
    }
)
const productSlice = createSlice({
    name: "productSlice",
    initialState: initialState,
    reducers: {
        sortByPrice: (state, action:PayloadAction<"asc"|"desc">) => {
            if (action.payload === "asc") {
                state.sort((a, b) => (a.price > b.price ? 1 : -1));
            } else {
                state.sort((a, b) => (b.price > a.price ? 1 : -1));
            }
        },
    }, 
    extraReducers: (build) => {
        build.addCase(fetchAllProducts.fulfilled, (state, action) => {
            if (action.payload && "message" in action.payload) {
                return state
            } else if (!action.payload) {
                return state
            }
            return action.payload
        })
        build.addCase(fetchAllProducts.rejected, (state, action) => {
            console.log("error in fetching data")
            return state
        })
        build.addCase(fetchAllProducts.pending, (state, action) => {
            console.log("data is loading ...")
            return state
        })
        build.addCase(fetchFeaturedProducts.fulfilled, (state, action) => {
            if (action.payload && "message" in action.payload) {
                return state
            } else if (!action.payload) {
                return state
            }
            return action.payload
        })
        build.addCase(fetchFeaturedProducts.rejected, (state, action) => {
            console.log("error in fetching data")
            return state
        })
        build.addCase(fetchFeaturedProducts.pending, (state, action) => {
            console.log("data is loading ...")
            return state
        })
        build.addCase(createProduct.fulfilled, (state, action) => {
            if (action.payload) {
                state.push(action.payload)
            } else {
                return state
            }
        })
        build.addCase(editProduct.fulfilled, (state, action) => {
            if (action.payload) {
                state.push(action.payload)
            } else {
                return state
            }
        })
    }
})
const productReducer = productSlice.reducer
export const {sortByPrice} = productSlice.actions
export default productReducer