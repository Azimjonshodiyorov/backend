import { createSlice, PayloadAction } from '@reduxjs/toolkit'
import { RootState } from '../store'

import { AuthType } from "../../types/Auth";

const initialState: AuthType = {
    token: null,
}
export const authSlice = createSlice({
    name: "auth",
    initialState,
    reducers: {
        setUser: (state, action: PayloadAction<AuthType>) => {
            localStorage.setItem(
                "user", JSON.stringify({ token: action.payload.token })
            )
            state.token = action.payload.token
        },
        logout: (state) => {
            localStorage.clear()
            state.token = null
        },
    }
})
export const selectAuth = (state: RootState) => state.persistedReducer.auth
const authReducer = authSlice.reducer;

export default authReducer
export const { setUser, logout } = authSlice.actions

