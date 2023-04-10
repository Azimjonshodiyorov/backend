import { ContactlessOutlined } from "@mui/icons-material";
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit"
import axios, { AxiosError, AxiosResponse } from "axios"

import { User } from "../../types/Auth";

const initialState: User[] = []

export const fetchAllUser = createAsyncThunk(
    'fetchAllUser',
    async () => {
        try {
            const jsondata = await fetch("https://api.escuelajs.co/api/v1/users")
            const data: User | Error = await jsondata.json()
            return data
        }
        catch (e: any) {
            console.log(e)
        }
    }
)
export const editUser = createAsyncThunk(
    "editUser",
    async (payload: { id: number, name: string, email: string, password: string }) => {
        try {
            const response: AxiosResponse<User, any> = await axios.put(`https://api.escuelajs.co/api/v1/users/${payload.id}`, payload)
            return response.data
        } catch (e) {
            console.log(e)
        }
    }
)
export const deleteUser = createAsyncThunk(
    "deleteUser",
    async (payload: { id: number }) => {
        try {
            const response: AxiosResponse<User, any> = await axios.delete(`https://api.escuelajs.co/api/v1/users/${payload.id}`)
            return response.data
        } catch (error) {
            const e = (error as AxiosError)
            return e
        }
    }
)
const userSlice = createSlice({
    name: "userSlice",
    initialState: initialState,
    reducers: {
    },
    extraReducers: (build) => {
        build.addCase(fetchAllUser.fulfilled, (state, action: User | any) => {
            if (action.payload && "message" in action.payload) {
                return state
            } else if (!action.payload) {
                return state
            }
            return action.payload
        })
        build.addCase(fetchAllUser.rejected, (state) => {
            console.log("error in fetching data")
            return state
        })
        build.addCase(fetchAllUser.pending, (state) => {
            // console.log("data is loading ...")
            return state
        })
        build.addCase(editUser.fulfilled, (state, action) => {
            if (action.payload) {
                state.push(action.payload)
            } else {
                return state
            }
        })
        // build.addCase(deleteUser.fulfilled, (state, action) => {
        //     if (action.payload as AxiosError) {
        //         console.log("The error message", action.payload)
        //         state.errorMessage = action.payload
        //     } else {
        //         return state
        //     }
        // })
    }
})
const userReducer = userSlice.reducer
export default userReducer

