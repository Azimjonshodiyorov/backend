import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

import { Login, Register } from '../types/Auth'

export const authApi = createApi({
    reducerPath: "authApi",
    baseQuery: fetchBaseQuery({
        baseUrl: "https://api.escuelajs.co/api/v1"
    }),
    endpoints: (builder) => ({
        loginUser: builder.mutation({
            query:( body: Login) => {
                return{
                    url: "/auth/login",
                    method: "post",
                    body
                }
            },
        }),
        registerUser: builder.mutation({
            query:( body: Register) => {
                return{
                    url: "/users/",
                    method: "post",
                    body
                }
            },
        }),
    }),
})
export const { useLoginUserMutation, useRegisterUserMutation } = authApi
