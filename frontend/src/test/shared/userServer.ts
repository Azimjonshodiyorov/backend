import { rest } from 'msw'
import { setupServer } from "msw/node"

import { userData } from './fakeData/userData'

const handler = [
    rest.get("https://api.escuelajs.co/api/v1/users", (req, res, ctx) => {
        return res(
            ctx.json(
                userData
            )
        )
    }),
    rest.put("https://api.escuelajs.co/api/v1/users/:id", async(req, res, ctx) => {
        const editUser:any = await req.json()
        const {id} = req.params
        const foundUser = userData.find(user => user.id === Number(id))
        if(foundUser) {
            return res(
                ctx.json({
                    ...foundUser,
                    ...editUser
                })      
            )
        }
        return res(
            ctx.status(404, 'User is not found')
        )
    }),
    rest.delete("https://api.escuelajs.co/api/v1/users/:id", async(req, res, ctx) => {
        const {id} = req.params
        const find = userData.find(user => user.id === Number(id))
        if(find) {
            return res(
                ctx.json(true)
            )
        }
        return res(
            ctx.status(404, 'User is not found')
        )
    })

]

const userServer = setupServer(...handler)
export default userServer