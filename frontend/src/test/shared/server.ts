import { rest } from 'msw'
import { setupServer } from "msw/node"

// const handler = [
//     rest.get('https://api.escuelajs.co/api/v1/products', (req, res, ctx) => {
//         return res(
//             ctx.json(
//                 [
//                     {
//                         id: 1,
//                         title: "Handmade Fresh Table",
//                         price: 300,
//                         description: "Andy shoes are designed to keeping in...",
//                         category: {
//                             "id": 2,
//                             "name": "Others",
//                             "image": "https://placeimg.com/640/480/any?r=0.591926261873231"
//                         },
//                         images: [
//                             "https://placeimg.com/640/480/any?r=0.9178516507833767",
//                             "https://placeimg.com/640/480/any?r=0.9300320592588625",
//                             "https://placeimg.com/640/480/any?r=0.8807778235430017"
//                         ]
//                     },
//                     {
//                         id: 3,
//                         title: "Handmade Fresh Table",
//                         price: 800,
//                         description: "Andy shoes are designed to keeping in...",
//                         category: {
//                             "id": 4,
//                             "name": "Others",
//                             "image": "https://placeimg.com/640/480/any?r=0.591926261873231"
//                         },
//                         images: [
//                             "https://placeimg.com/640/480/any?r=0.9178516507833767",
//                             "https://placeimg.com/640/480/any?r=0.9300320592588625",
//                             "https://placeimg.com/640/480/any?r=0.8807778235430017"
//                         ]
//                     },
//                     {
//                         id: 5,
//                         title: "Handmade Fresh Table",
//                         price: 570,
//                         description: "Andy shoes are designed to keeping in...",
//                         category: {
//                             "id": 6,
//                             "name": "Others",
//                             "image": "https://placeimg.com/640/480/any?r=0.591926261873231"
//                         },
//                         images: [
//                             "https://placeimg.com/640/480/any?r=0.9178516507833767",
//                             "https://placeimg.com/640/480/any?r=0.9300320592588625",
//                             "https://placeimg.com/640/480/any?r=0.8807778235430017"
//                         ]
//                     }
//                 ]
//             )
//         )
//     })
// ]
// const server = setupServer(...handler)
// export default server
