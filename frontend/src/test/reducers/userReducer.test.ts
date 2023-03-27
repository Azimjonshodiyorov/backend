
import { AnyAction, EmptyObject, ThunkMiddleware } from '@reduxjs/toolkit';
import { ToolkitStore } from '@reduxjs/toolkit/dist/configureStore';
import { PersistPartial } from 'redux-persist/es/persistReducer';
import { fetchAllUser, editUser, deleteUser } from '../../redux/reducer/userReducer'
import { createStore, RootState, store } from '../../redux/store'

import userServer from '../shared/userServer'

beforeAll(() => {
    userServer.listen()
})

afterAll(() => {
    userServer.close()
})

describe("test all the actions", () => {
    test("Should return initial state", () => {
        expect(store.getState().userReducer.length).toBe(0)
    })
    test("Should fetch all user", async () => {
        const store = createStore()
        await store.dispatch(fetchAllUser())
        expect(store.getState().userReducer.length).toBe(3)
    })
    test("Should update user", async () => {
        const updateUserInfo: any = {
            id: 1,
            updateInfo: {
                email: "anu@mail.com",
                name: "anu"
            }
        }
        const store = createStore()
        await store.dispatch(fetchAllUser())
        await store.dispatch(editUser(updateUserInfo))
        // expect(store.getState().users[0].email).toBe("anu@mail.com")
    })
    test("Should delete selected user", async () => {
        const deleteId:any = 3
        const store = createStore()
        await store.dispatch(fetchAllUser())
        await store.dispatch(deleteUser(deleteId))
        expect(store.getState().userReducer.length).toBe(3)
    })

})