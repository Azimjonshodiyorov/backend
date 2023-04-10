import { rest } from 'msw'
import { setupServer } from "msw/node"

import { productData } from './fakeData/productData'

const handler = [
    rest.get('https://api.escuelajs.co/api/v1/products?offset=0&limit=12', (req, res, ctx) => {
        return res(
            ctx.json(
                productData
            )
        )
    }),
    rest.post('https://api.escuelajs.co/api/v1/products/', async(req, res, ctx) => {
        const newProduct: any = await req.json()
        return res(
            ctx.json(newProduct)
        )
    }),
    rest.delete('https://api.escuelajs.co/api/v1/products/:id', async(req, res, ctx) => {
        const {id} = req.params
        const foundProduct = productData.find(product => product.id === Number(id))
        if(foundProduct) {
            return res(
                ctx.json(true)
            )
        }
        return res(
            ctx.status(404, 'Product is not found')
        )
    }),
    rest.put("https://api.escuelajs.co/api/v1/products/1", async(req, res, ctx) => {
        const editedProduct: any = await req.json()
        const {id} = req.params
        const find = productData.find(product => product.id === Number(id))
        if(find) {
            return res(
                ctx.json({
                    ...find,
                    ...editedProduct
                })
            )
        }
        return res(
            ctx.status(404, 'Product is not found')
        )
    })
]
const productServer = setupServer(...handler)
export default productServer
