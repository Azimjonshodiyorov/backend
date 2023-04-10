export interface AuthType {
    token: string | null
}
export type Role = "admin"|"customer"

export interface User {
    errorMessage: string
    userDetail: any
    id: number
    email: string
    password: string
    name: string
    role: string
    avatar?: string
}
export interface Login {
    email: string
    password: string
}
export interface Register {
    email: string
    password: string
    name: string
    avatar: string
}